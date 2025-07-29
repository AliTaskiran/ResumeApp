using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using EntityLayer;

namespace ResumeApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Eğer kullanıcı zaten giriş yapmışsa, rolüne göre yönlendir
                if (User.HasClaim(ClaimTypes.Role, "Employer"))
                {
                    return RedirectToAction("Dashboard", "Employer");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string email, string password, string userType)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Email ve şifre gereklidir.");
                return View();
            }

            var user = _userService.ValidateUser(email, password);

            if (user != null)
            {
                // userType kontrolü - İşveren mi Aday mı
                if (userType == "employer" && !user.IsEmployer)
                {
                    ModelState.AddModelError("", "Bu hesap işveren hesabı değil. Aday girişini deneyin.");
                    return View();
                }
                else if (userType == "candidate" && user.IsEmployer)
                {
                    ModelState.AddModelError("", "Bu hesap aday hesabı değil. İşveren girişini deneyin.");
                    return View();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.IsEmployer ? "Employer" : "Candidate")
                };

                if (user.IsEmployer && !string.IsNullOrEmpty(user.CompanyName))
                {
                    claims.Add(new Claim("CompanyName", user.CompanyName));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                    });

                // Rolüne göre yönlendir
                if (user.IsEmployer)
                {
                    return RedirectToAction("Dashboard", "Employer");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Geçersiz email veya şifre.");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(User user, string userType)
        {
            // İşveren için şirket adı kontrolü
            if (userType == "employer" && string.IsNullOrEmpty(user.CompanyName))
            {
                ModelState.AddModelError("CompanyName", "İşveren hesabı için şirket adı gereklidir.");
            }

            if (ModelState.IsValid)
            {
                // Email kontrol et
                var existingUser = _userService.GetUserByEmail(user.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Bu email adresi zaten kullanılıyor.");
                    return View(user);
                }

                // Şifreyi hash'le
                user.Password = _userService.HashPassword(user.Password);
                
                // Kullanıcı tipini ayarla
                user.IsEmployer = userType == "employer";
                user.CreatedDate = DateTime.Now;
                user.IsActive = true;

                _userService.TAdd(user);

                TempData["SuccessMessage"] = "Kayıt başarılı! Şimdi giriş yapabilirsiniz.";
                return RedirectToAction("Index");
            }

            return View(user);
        }
    }
} 
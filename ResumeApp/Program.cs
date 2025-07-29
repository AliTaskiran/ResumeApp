using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Concrete;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Authentication ekle
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.LogoutPath = "/Login/Logout";
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
        options.SlidingExpiration = true;
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    });

// Session desteği ekle
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// DbContext'i servislere ekleyelim (sadece bir kez ekliyoruz)
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Service kayıtları - bunlar da app.Build()'den önce olmalı
// Chat servisleri
builder.Services.AddScoped<IChatMessageService, ChatMessageManager>();
builder.Services.AddScoped<IChatMessageDal, EfChatMessageDal>();
builder.Services.AddScoped<IChatbotService, ChatbotService>();

// Resume servisleri
builder.Services.AddScoped<IResumeService, ResumeManager>();
builder.Services.AddScoped<IResumeDal, EfResumeDal>();

// AI ve Matching servisleri
builder.Services.AddScoped<IAIService, AIService>();
builder.Services.AddScoped<IMatchingService, MatchingService>();

// Job Posting servisleri
builder.Services.AddScoped<IJobPostingService, JobPostingManager>();
builder.Services.AddScoped<IJobPostingDal, EfJobPostingDal>();

// User servisleri
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();

// Job Application servisleri
builder.Services.AddScoped<IJobApplicationService, JobApplicationManager>();
builder.Services.AddScoped<IJobApplicationDal, EfJobApplicationDal>();

// Tüm servis kayıtlarından SONRA app.Build() çağrılmalı
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Session middleware'ini ekle
app.UseSession();

// Authentication ve Authorization ekle
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
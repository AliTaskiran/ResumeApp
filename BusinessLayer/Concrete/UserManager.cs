using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void TAdd(User t)
        {
           _userDal.Insert(t);
        }

        public void TDelete(User t)
        {
            _userDal.Delete(t);
        }

        public User TGetById(int id)
        {
          return _userDal.GetById(id);
        }

        public List<User> TGetList()
        {
            return _userDal.GetList();
        }

        public void TUpdate(User t)
        {
          _userDal.Update(t);
        }

        // Authentication metodları
        public string HashPassword(string password)
        {
            // Random salt oluştur
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Şifreyi hash'le
            var hashedPassword = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8);

            // Salt ve hash'i birleştir
            return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hashedPassword)}";
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            try
            {
                var parts = hashedPassword.Split('.');
                if (parts.Length != 2)
                    return false;

                var salt = Convert.FromBase64String(parts[0]);
                var storedHash = Convert.FromBase64String(parts[1]);

                var hashToVerify = KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8);

                return storedHash.SequenceEqual(hashToVerify);
            }
            catch
            {
                return false;
            }
        }

        public User ValidateUser(string email, string password)
        {
            var user = _userDal.GetList().FirstOrDefault(x => x.Email == email && x.IsActive);
            if (user != null && VerifyPassword(user.Password, password))
            {
                return user;
            }
            return null;
        }

        public User GetUserByEmail(string email)
        {
            return _userDal.GetList().FirstOrDefault(x => x.Email == email);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IUserService : IGenericService<EntityLayer.User>
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string password);
        User ValidateUser(string email, string password);
        User GetUserByEmail(string email);
    }
}

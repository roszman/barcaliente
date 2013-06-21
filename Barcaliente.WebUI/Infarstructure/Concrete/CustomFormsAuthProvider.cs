using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using Barcaliente.Domain.Abstract;
using Barcaliente.WebUI.Infarstructure.Abstract;

namespace Barcaliente.WebUI.Infarstructure.Concrete
{
    public class CustomFormsAuthProvider : IAuthProvider
    {
        private IUserRepository _userRepository;

        public CustomFormsAuthProvider(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        public bool AuthenticateAndLogIn(string username, string password)
        {
            string salt = CreateSalt(username);
            string hashedPassword = HashPassword(salt, password);
            bool isValid = _userRepository.Users.Any(dbUser => dbUser.UserName == username && dbUser.Password == hashedPassword);
            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return isValid;
        }

        public void LogOff()
        {
            FormsAuthentication.SignOut();
        }

        private string CreateSalt(string userName)
        {
            Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(userName, System.Text.Encoding.Default.GetBytes("thomikwla"), 10000);
            return Convert.ToBase64String(hasher.GetBytes(25));
        }

        private string HashPassword(string salt, string password)
        {
            Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(password, System.Text.Encoding.Default.GetBytes(salt), 10000);
            return Convert.ToBase64String(hasher.GetBytes(25));
        }
    }
}
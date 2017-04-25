using SocialMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SocialMusic.Handlers
{
    public class AuthentificationHandler
    {
        private const string AUTH_KEY = "USER";

        private HttpSessionStateBase Session { get; set; }

        public AuthentificationHandler(HttpSessionStateBase session)
        {
            this.Session = session;
        }

        public void Authenticate(User user)
        {
            this.Session.Add(AUTH_KEY, user);
        }
        public bool LogIn(User user)
        {
            
            using (var db = new UserDbContext())
            {
                User dbUser = db.Users.FirstOrDefault(s => s.Username == user.Username);
                if (dbUser == null)
                {
                    return false;
                }
                if (dbUser.Password == HashPassword(user.Password))
                {
                    Authenticate(dbUser);
                    return true;
                }
                return false;
            }
            //using (var db = new UserDbContext())
            //{
            //    /* Fetch the stored value */
            //    User dbUser = db.Users.FirstOrDefault(s => s.Username == user.Username);
            //    string savedPasswordHash = dbUser.Password;
            //    /* Extract the bytes */
            //    byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            //    /* Get the salt */
            //    byte[] salt = new byte[16];
            //    Array.Copy(hashBytes, 0, salt, 0, 16);
            //    /* Compute the hash on the password the user entered */
            //    var pbkdf2 = new Rfc2898DeriveBytes(user.Password, salt, 10000);
            //    byte[] hash = pbkdf2.GetBytes(20);
            //    /* Compare the results */
            //    for (int i = 0; i < 20; i++)
            //        if (hashBytes[i + 16] != hash[i])
            //            return false;
            //    return true;
            //}
        }
        public void LogOut()
        {
            this.Session.Abandon();
        }
        public bool IsAuthenticated()
        {
            return this.Session[AUTH_KEY] != null;
        }
        public string HashPassword(string input)
        {
            
            using (var md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));



                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sBuilder.Append(hashBytes[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
            
            ////Create the salt
            //byte[] salt;
            //new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            ////Create the Rfc2898DeriveBytes and get the hash value
            //var pbkdf2 = new Rfc2898DeriveBytes(input, salt, 10000);
            //byte[] hash = pbkdf2.GetBytes(20);

            ////Combine the salt and password bytes for later use:
            //byte[] hashBytes = new byte[36];
            //Array.Copy(salt, 0, hashBytes, 0, 16);
            //Array.Copy(hash, 0, hashBytes, 16, 20);

            ////Turn the combined salt+hash into a string
            //string savedPasswordHash = Convert.ToBase64String(hashBytes);
            //return savedPasswordHash;
        }
    }
}
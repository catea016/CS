using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordApplication
{
    class PasswordManager
    {
        HashPassword hashPass = new HashPassword();

        //method to hash the password+salt

        public string GeneratePasswordHash(string plainTextPassword, out string salt)
        {
            salt = SaltGenerator.GetSaltString();

            string finalString = plainTextPassword + salt;

            return hashPass.GetPasswordHashAndSalt(finalString);
        }
        //method to verify the real password and the password entered by the user
        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;
            return hash == hashPass.GetPasswordHashAndSalt(finalString);
        }
    }
}

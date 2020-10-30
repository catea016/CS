using System;

namespace PasswordApplication
{
    class Program
    {
        // repository class for DB operations
        static UserDB userDB = new UserDB();

        static PasswordManager pwdManager = new PasswordManager();

        static void Main(string[] args)
        {
            string salt = SimulateUserCreation();

            // Now lets simualte the password comparison
            SimulateLogin(salt);

            Console.ReadLine();
        }

        public static string SimulateUserCreation()
        {
            Console.WriteLine("Let us first test the password hash creation i.e. User registration process");
            Console.WriteLine("Please enter user id");
            string userid = Console.ReadLine();

            Console.WriteLine("Please enter password");
            string password = Console.ReadLine();

            string salt = null;

            string passwordHash = pwdManager.GeneratePasswordHash(password, out salt);

            //save the values in the database
            User user = new User
            {
                UserId = userid,
                PasswordHash = passwordHash,
                Salt = salt
            };

            //Add the User to the database
            userDB.AddUser(user);

            return salt;
        }

        public static void SimulateLogin(string salt)
        {
            Console.WriteLine("Now lets simulate the password comparison");

            Console.WriteLine("Please enter user id");
            string userid = Console.ReadLine();

            Console.WriteLine("Please enter password");
            string password = Console.ReadLine();

            // Lets retrieve the values from the database
            User user2 = userDB.GetUser(userid);

            bool result = pwdManager.IsPasswordMatch(password, user2.Salt, user2.PasswordHash);

            if (result == true)
            {
                Console.WriteLine("Password Matched");
            }
            else
            {
                Console.WriteLine("Password not Matched");
            }
        }

    }
}

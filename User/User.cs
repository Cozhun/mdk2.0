using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdk2._0.User
{
    class User
    {
        private string username;
        private string password;
        private List<User> userList;


        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.userList = new List<User>();

        }

        public void AddUser()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            User newUser = new User(username, password);
            userList.Add(newUser);

            Console.WriteLine("User added successfully!");
        }

        public void RemoveUser()
        {
            Console.WriteLine("Enter your username:");
            string enteredUsername = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string enteredPassword = Console.ReadLine();

            // Find user by username and check if the entered password matches
            User userToRemove = userList.Find(user => user.username == enteredUsername && user.password == enteredPassword);

            if (userToRemove != null)
            {
                Console.WriteLine("Are you sure you want to remove your account? (Y/N)");
                string confirmation = Console.ReadLine();

                if (confirmation.ToUpper() == "Y")
                {
                    userList.Remove(userToRemove);
                    Console.WriteLine("User removed successfully!");
                }
                else
                {
                    Console.WriteLine("User removal canceled.");
                }
            }
            else
            {
                Console.WriteLine("Invalid username or password. User removal failed.");
            }
        }

        public bool Login()
        {
            Console.WriteLine("Enter your username:");
            string enteredUsername = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string enteredPassword = Console.ReadLine();

            // Find user by username and check if the entered password matches
            User loggedInUser = userList.Find(user => user.username == enteredUsername && user.password == enteredPassword);

            if (loggedInUser != null)
            {
                Console.WriteLine("Login successful!");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid username or password. Login failed.");
                return false;
            }
        }
    }
}

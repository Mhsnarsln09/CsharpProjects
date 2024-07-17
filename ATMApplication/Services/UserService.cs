using System.Collections.Generic;
using System.IO;

namespace ATMApplication.Services
{
    public class UserService
    {
        private readonly string usersFile = "Data/users.txt";
        private readonly List<string> registeredUsers;

        public UserService()
        {
            registeredUsers = new List<string>();
            LoadUsers();
        }

        private void LoadUsers()
        {
            if (File.Exists(usersFile))
            {
                registeredUsers.AddRange(File.ReadAllLines(usersFile));
            }
        }

        public bool IsValidUser(string userId)
        {
            return registeredUsers.Contains(userId);
        }
    }
}

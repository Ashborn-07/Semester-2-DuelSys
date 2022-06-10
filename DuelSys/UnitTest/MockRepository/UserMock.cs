using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;

namespace UnitTest
{
    public class UserMock : IUserRepository
    {
        private List<User> users = new List<User>() { 
            new User(2, "test1", "$2a$11$ygueCfbSox/y8ZDCwzLGDuztf4VzDeakK/cBOqET0yLo7kJHpwCl2", "Lili", "Ivanova", 21, Gender.FEMALE, "lili@gmail.com", new WinRate(0, 0)) };
        // the password is password imagine
        private List<User> usersWithMatches = new List<User>() {
            new User(1, "test1", "tester1", "first", 21, Gender.MALE, "asd@gmail.com", new WinRate(0, 0)),
            new User(2, "test2", "tester2", "second", 23, Gender.FEMALE, "asfas@gmail.nl", new WinRate(0, 0)),
            new User(3, "test3", "tester3", "thirs", 27, Gender.UNSPECIFIED, "kgkdkgd@gmail.com", new WinRate(0, 0))};


        public List<User> GetUsers()
        {
            return users;
        }

        public User CheckUserCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(User user)
        {
            users.Add(user);
        }

        public User ReturnUserByUsername(string username)
        {
            foreach (var user in users)
            {
                if (user.UserName == username)
                {
                    return user;
                }
            }

            return null;
        }

        public void UpdateUsersWinrate(List<User> players)
        {
            foreach (var player in players)
            {
                foreach (var user in usersWithMatches)
                {
                    if (user.Id == player.Id)
                    {
                        user.WinRate = player.WinRate;
                    }
                }
            }
        }

        public bool UsernameTaken(string username)
        {
            bool taken = false;

            foreach (var user in users)
            {
                if (user.UserName == username)
                {
                    taken = true;
                }
            }

            return taken;
        }

        public bool EmailAlreadyRegistered(string email)
        {
            bool taken = false;

            foreach (var user in users)
            {
                if (user.Email == email)
                {
                    taken = true;
                }
            }

            return taken;
        }
    }
}

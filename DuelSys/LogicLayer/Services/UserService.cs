using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class UserService
    {
        private IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public User CheckUserCredentials(string username, string password)
        {
            User user = repository.ReturnUserByUsername(username);

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }
            }

            throw new UserException("Incorrect username or password!");
        }

        public void RegisterUser(User user)
        {
            if (!repository.UsernameTaken(user.UserName))
            {
                if (!repository.EmailAlreadyRegistered(user.Email))
                {
                    User newUser = new User(user.UserName, BCrypt.Net.BCrypt.HashPassword(user.Password), user.FirstName, user.LastName, user.Age, user.Gender, user.Email, user.WinRate);
                    repository.RegisterUser(newUser);
                    return;
                }

                throw new UserException("This email is already registered!");
            }

            throw new UserException("Username is already taken.");
        }
    }
}

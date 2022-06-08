using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IUserRepository
    {
        public abstract User CheckUserCredentials(string username, string password);

        public abstract void RegisterUser(User user);

        public abstract User ReturnUserByUsername(string username);

        public abstract void UpdateUsersWinrate(List<User> players);

        public abstract bool UsernameTaken(string username);
    }
}

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
    }
}

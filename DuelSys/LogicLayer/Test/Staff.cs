using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Staff : User
    {
        public Staff(string username, string password, string firstName, string lastName, string email) : base(username, password, firstName, lastName, email) { }
   
        public Staff(int id, string username, string password, string firstName, string lastName, string email) : base(id, username, password, firstName, lastName, email) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Staff : User
    {
        private string bsn;
        private string address;

        public Staff(string username, string password, string firstName, string lastName, string email, string bsn, string address) : base(username, password, firstName, lastName, email) 
        {
            this.bsn = bsn;
            this.address = address;
        }
   
        public Staff(int id, string username, string password, string firstName, string lastName, string email, string bsn, string address) : base(id, username, password, firstName, lastName, email) 
        {
            this.bsn = bsn;
            this.address = address;
        }
    }
}

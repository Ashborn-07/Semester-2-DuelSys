using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSynthesis
{
    public class User
    {
        private int id;
        private string username;

        public int Id { get { return this.id; } }
        public string UserName { get { return this.username; } set { this.username = value; } }

        public User(int id, string username)
        {
            this.id = id;
            this.username = username;
        }
    }
}

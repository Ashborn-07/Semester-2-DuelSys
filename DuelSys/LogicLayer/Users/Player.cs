using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Player : User
    {
        private WinRate winRate;

        public WinRate WinRate { get { return this.winRate; } set { this.winRate = value; } }

        public Player(string username, string password, string firstName, string lastName, string email, WinRate winRate) : base(username, password, firstName, lastName, email) 
        {
            this.winRate = winRate;
        }

        public Player(int id, string username, string password, string firstName, string lastName, string email, WinRate winRate) : base(id, username, password, firstName, lastName, email) 
        {
            this.winRate = winRate;
        }
    }
}

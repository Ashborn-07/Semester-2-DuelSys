using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class WinRate
    {
        private int wins;
        private int loses;

        public int Wins { get { return wins; } set { wins = value; } }
        public int Loses { get { return loses; } set { loses = value; } }

        public WinRate(int wins, int loses)
        {
            this.wins = wins;
            this.loses = loses;
        }

        public string WinRatePercentage()
        {
            if (wins == 0 && loses == 0)
            {
                return "No matches were played by this user";
            } else
            {
                return $"{(wins / (wins + loses)) * 100}% wr";
            }
        }
    }
}

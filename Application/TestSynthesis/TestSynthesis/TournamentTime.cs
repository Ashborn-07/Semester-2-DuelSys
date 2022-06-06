using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSynthesis
{
    public class TournamentTime
    {
        private DateTime start;
        private DateTime end;

        public DateTime Start { get { return start; } set { this.start = value; } }
        public DateTime End { get { return end; } set { this.end = value; } }

        public TournamentTime(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
        }
    }
}

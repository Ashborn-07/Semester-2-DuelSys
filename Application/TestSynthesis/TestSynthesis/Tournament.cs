using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSynthesis
{
    public class Tournament
    {
        private int id;
        private string name;
        private string description;
        private string location;
        private TournamentTime time;

        public int Id { get { return id; } }
        public string Name { get { return name; } set { this.name = value; } }
        public string Description { get { return description; } set { this.description = value; } }
        public string Location { get { return location; } set { this.location = value; } }
        public TournamentTime Time { get { return time; } set { time = value; } }


        public Tournament(int id, string name, string description, string location, TournamentTime time)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.location = location;
            this.time = time;
        }
    }
}

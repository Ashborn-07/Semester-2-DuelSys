using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Tournament
    {
        private int id;
        private string name;
        private string description;
        private string location;
        private Sport sport;
        private TournamentTime time;
        private string type;
        private int max_players;
        private int min_players;

        public int Id { get { return id; } }
        public string Name { get { return name; } set { this.name = value; } }
        public string Description { get { return description; } set { this.description = value; } }
        public string Location { get { return location; } set { this.location = value; } }
        public Sport Sport { get { return sport; } set { this.sport = value; } }
        public TournamentTime Time { get { return time; } set { time = value; } }
        public string Type { get { return type; } set { this.type = value; } }
        public int Max_players { get { return max_players; } set { this.max_players = value; } }
        public int Min_players { get { return min_players; } set { this.min_players = value; } }

        public Tournament(int id, string name, string description, string location, Sport sport, TournamentTime time, string type, int max_players, int min_players)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.location = location;
            this.sport = sport;
            this.time = time;
            this.type = type;
            this.max_players = max_players;
            this.min_players = min_players;
        }
    }
}

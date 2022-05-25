using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;

namespace DataAccessLayer
{
    public class TournamentRepository : DataBaseHandler, ITournamentRepository
    {
        public TournamentRepository(string path) : base(path) { }

        public List<string> ListOfSports()
        {
            List<string> list = new List<string>();

            Connect();

            string sql = "SELECT name FROM synth_sport";
            Cmd = new MySqlCommand(sql, Con);

            try
            {
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    string name = Reader.GetString(0);
                    list.Add(name);
                }
            }
            finally
            {
                Disconnect();
            }

            return list;
        }

        public List<Tournament> ListOfTournaments()
        {
            List<Tournament> tournaments = new List<Tournament>();

            Connect();

            string sql = "SELECT * FROM synth_tournament AS t INNER JOIN synth_sport AS s ON t.`sport` = s.`id`";
            Cmd = new MySqlCommand(sql, Con);

            try
            {
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    int id = Reader.GetInt32(0);
                    string name = Reader.GetString(1);
                    string description = Reader.GetString(2);
                    string location = Reader.GetString(3);
                    int sport_id = Reader.GetInt32(4);
                    DateTime start = Reader.GetDateTime(5);
                    DateTime end = Reader.GetDateTime(6);
                    string type = Reader.GetString(7);
                    int minPlayers = Reader.GetInt32(8);
                    int maxPlayers = Reader.GetInt32(9);
                    string sport_name = Reader.GetString(11);

                    Sport sport = new Sport(sport_id, sport_name);
                    TournamentTime tournamentTime = new TournamentTime(start, end);

                    tournaments.Add(new Tournament(id, name, description, location, sport, tournamentTime, type, maxPlayers, minPlayers));
                }
            }
            finally
            {
                Disconnect();
            }

            return tournaments;
        }

        public int CreateTournament(Tournament tournament)
        {
            int i = -10;

            Connect();

            string sql = "INSERT INTO synth_tournament (`name`, `description`, `location`, `sport`, `start`, `end`, `system`, `min_players`, `max_players`) VALUES (@name, @description, @location, @sport, @start, @end, @system, @min_players, @max_players)";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@name", tournament.Name);
            Cmd.Parameters.AddWithValue("@description", tournament.Description);
            Cmd.Parameters.AddWithValue("location", tournament.Location);
            Cmd.Parameters.AddWithValue("@sport", tournament.Sport.Id);
            Cmd.Parameters.AddWithValue("@start", tournament.Time.Start);
            Cmd.Parameters.AddWithValue("@end", tournament.Time.End);
            Cmd.Parameters.AddWithValue("@system", tournament.Type);
            Cmd.Parameters.AddWithValue("@min_players", tournament.Min_players);
            Cmd.Parameters.AddWithValue("@max_players", tournament.Max_players);

            try
            {
                i = Cmd.ExecuteNonQuery();
            }
            finally
            {
                Disconnect();
            }

            return i;
        }
    }
}

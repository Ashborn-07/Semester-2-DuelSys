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

        public void RegisterPlayer(int tournamentId, int playerId)
        {
            Connect();

            string sql = "INSERT INTO synth_contestants (`tournament_id`, `player_id`) VALUES (@tournamentId, @playerId)";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@tournamentId", tournamentId);
            Cmd.Parameters.AddWithValue("@playerId", playerId);

            try
            {
                Cmd.ExecuteNonQuery();
            } finally
            {
                Disconnect();
            }
        }

        public bool PlayerAlreadyRegistered(int tournamentId, int playerId)
        {
            bool valid = false;

            Connect();

            string sql = "SELECT * FROM synth_contestants WHERE `tournament_id` = @tournamentId AND `player_id` = @playerId";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@tournamentId", tournamentId);
            Cmd.Parameters.AddWithValue("@playerId", playerId);

            try
            {
                Reader = Cmd.ExecuteReader();

                if (Reader.Read())
                {
                    valid = true;
                }
            }
            finally
            {
                Disconnect();
            }

            return valid;
        }

        public void CancelRegistrationTournament(int tournamentId, int playerId)
        {
            Connect();

            string sql = "DELETE FROM synth_contestants WHERE `tournament_id` = @tournamentId AND `player_id` = @playerId";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@tournamentId", tournamentId);
            Cmd.Parameters.AddWithValue("@playerId", playerId);

            try
            {
                Cmd.ExecuteNonQuery();
            } finally
            {
                Disconnect();
            }
        }

        public int CountOfPlayers(int tournamentId)
        {
            int players = 0;

            Connect();

            string sql = "SELECT COUNT(player_id) FROM synth_contestants WHERE tournament_id = @tournamentId";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@tournamentId", tournamentId);

            try
            {
                Reader = Cmd.ExecuteReader();

                if (Reader.Read())
                {
                    players = Reader.GetInt32(0);
                }
            } finally
            {
                Disconnect();
            }

            return players;
        }

        public List<User> ListOfUsers(int tournamentId)
        {
            List<User> users = new List<User>();

            Connect();

            string sql = "SELECT * FROM synth_contestants AS c INNER JOIN synth_user AS u ON c.player_id = u.id WHERE c.tournament_id = @tournamentId";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@tournamentId", tournamentId);

            try
            {
                Reader = Cmd.ExecuteReader();

                while(Reader.Read())
                {
                    int id = Reader.GetInt32(2);
                    string username = Reader.GetString(3);
                    string firstName = Reader.GetString(5);
                    string lastName = Reader.GetString(6);
                    int age = Reader.GetInt32(7);
                    string gender = Reader.GetString(8);
                    string email = Reader.GetString(9);
                    int wins = Reader.GetInt32(10);
                    int loses = Reader.GetInt32(11);

                    User user = new User(id, username, firstName, lastName, age, (Gender)Enum.Parse(typeof(Gender), gender), email, new WinRate(wins, loses));
                    users.Add(user);
                }
            } finally
            {
                Disconnect();
            }

            return users;
        }
    }
}

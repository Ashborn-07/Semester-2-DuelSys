using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LogicLayer;

namespace DataAccessLayer
{
    public class MatchRepository : DataBaseHandler, IMatchRepository
    {
        public MatchRepository(string path) : base(path) { }

        public List<User> GetTournamentPlayers(int tournamentId)
        {
            List<User> players = new List<User>();

            Connect();

            string sql = "SELECT * FROM synth_contestants AS c INNER JOIN synth_user AS u ON c.player_id = u.id WHERE tournament_id = @tournamentId";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@tournamentId", tournamentId);

            try
            {
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    int userId = Reader.GetInt32(2);
                    string username = Reader.GetString(3);
                    string firstName = Reader.GetString(5);
                    string lastName = Reader.GetString(6);
                    int age = Reader.GetInt32(7);
                    string gender = Reader.GetString(8);
                    string email = Reader.GetString(9);
                    int wins = Reader.GetInt32(10);
                    int loses = Reader.GetInt32(11);

                    players.Add(new User(userId, username, firstName, lastName, age, (Gender)Enum.Parse(typeof(Gender), gender), email, new WinRate(wins, loses)));
                }
            } finally
            {
                Disconnect();
            }

            return players;
        }

        public void WriteMatchesIntoDataBase(List<Match> matches)
        {
            Connect();

            string sql = "INSERT INTO synth_matchup (`tournament_id`, `date`, `player_1`, `player_2`) VALUES (@tournamentId, @date, @player1, @player2)";

            try
            {
                foreach (var match in matches)
                {
                    Cmd = new MySqlCommand(sql, Con);
                    Cmd.Parameters.AddWithValue("@tournamentId", match.Tournament.Id);
                    Cmd.Parameters.AddWithValue("@date", match.Tournament.Time.Start.ToString("yyyy-MM-dd"));
                    Cmd.Parameters.AddWithValue("@player1", match.Player1.Id);
                    Cmd.Parameters.AddWithValue("@player2", match.Player2.Id);
                    Cmd.ExecuteNonQuery();
                }
            } catch (MySqlException ex) {

            }
            finally
            {
                Disconnect();
            }
        }

        public List<Match> GetMatches(Tournament tournament)
        {
            List<Match> matches = new List<Match>();

            Connect();

            string sql = "SELECT m.id, m.date, m.score_p1, m.score_p2, m.winner AS winner, u.id, u.username, " +
                "u.first_name, u.last_name, u.age, u.gender, u.email, u.wins, u.loses, us.id, " +
                "us.username, us.first_name, us.last_name, us.age, us.gender, us.email, us.wins, " +
                "us.loses FROM synth_matchup AS m INNER JOIN synth_user AS u ON m.player_1 = u.id " +
                "INNER JOIN synth_user AS us ON m.player_2 = us.id WHERE m.tournament_id = @tournamentId";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@tournamentId", tournament.Id);

            try
            {
                Reader = Cmd.ExecuteReader();

                while(Reader.Read())
                {
                    int matchId = Reader.GetInt32(0);
                    DateTime date = Reader.GetDateTime(1);
                    int[] scores = new int[2] { Reader.GetInt32(2), Reader.GetInt32(3)};
                    int player1Id = Reader.GetInt32(5);
                    string player1Username = Reader.GetString(6);
                    string player1FirstName = Reader.GetString(7);
                    string player1LastName = Reader.GetString(8);
                    int player1Age = Reader.GetInt32(9);
                    string player1Gender = Reader.GetString(10);
                    string player1Email = Reader.GetString(11);
                    int player1Wins = Reader.GetInt32(12);
                    int player1Loses = Reader.GetInt32(13);
                    int player2Id = Reader.GetInt32(14);
                    string player2Username = Reader.GetString(15);
                    string player2FirstName = Reader.GetString(16);
                    string player2LastName = Reader.GetString(17);
                    int player2Age = Reader.GetInt32(18);
                    string player2Gender = Reader.GetString(19);
                    string player2Email = Reader.GetString(20);
                    int player2Wins = Reader.GetInt32(21);
                    int player2Loses = Reader.GetInt32(22);

                    if (Reader["winner"] != DBNull.Value)
                    {
                        int winner = Reader.GetInt32(4);

                        matches.Add(new Match(matchId, tournament, date, 
                            new User(player1Id, player1Username, player1FirstName, player1LastName, player1Age,
                        (Gender)Enum.Parse(typeof(Gender), player1Gender), player1Email, new WinRate(player1Wins, player1Loses)),
                        new User(player2Id, player2Username, player2FirstName, player2LastName, player2Age,
                        (Gender)Enum.Parse(typeof(Gender), player2Gender), player2Email, new WinRate(player2Wins, player2Loses)), scores, winner));
                    } else
                    {
                        matches.Add(new Match(matchId, tournament, date,
                        new User(player1Id, player1Username, player1FirstName, player1LastName, player1Age,
                        (Gender)Enum.Parse(typeof(Gender), player1Gender), player1Email, new WinRate(player1Wins, player1Loses)),
                        new User(player2Id, player2Username, player2FirstName, player2LastName, player2Age,
                        (Gender)Enum.Parse(typeof(Gender), player2Gender), player2Email, new WinRate(player2Wins, player2Loses)), scores));
                    }
                }
            } finally
            {
                Disconnect();
            }

            return matches;
        }

        public void UpdateScoreOfMatch(Match match)
        {
            Connect();

            string sql = "UPDATE synth_matchup SET `score_p1` = @player1Score, `score_p2` = @player2Score, `winner` = @winner WHERE id = @id";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@player1Score", match.Scores[0]);
            Cmd.Parameters.AddWithValue("@player2Score", match.Scores[1]);
            Cmd.Parameters.AddWithValue("@winner", match.Winner);
            Cmd.Parameters.AddWithValue("@id", match.Id);

            try
            {
                Cmd.ExecuteNonQuery();
            } finally
            {
                Disconnect();
            }
        }
    }
}

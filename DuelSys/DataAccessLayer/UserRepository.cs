using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class UserRepository : DataBaseHandler, IUserRepository
    {
        public UserRepository(string path) : base(path) { }

        // not used. It was used as log in for desktop before
        public User CheckUserCredentials(string username, string password)
        {
            User user = null;
            Connect();

            string sql = "SELECT * FROM synth_user WHERE username = @username AND password = @password";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@username", username);
            Cmd.Parameters.AddWithValue("@password", password);

            try
            {
                Reader = Cmd.ExecuteReader();

                if (Reader.Read())
                {
                    int id = Reader.GetInt32(0);
                    string userName = Reader.GetString(1);
                    string password1 = Reader.GetString(2);
                    string firstName = Reader.GetString(3);
                    string lastName = Reader.GetString(4);
                    int age = Reader.GetInt32(5);
                    string gender = Reader.GetString(6);
                    string email = Reader.GetString(7);
                    int wins = Reader.GetInt32(8);
                    int loses = Reader.GetInt32(9);
                    

                    user = new User(id, userName, password1, firstName, lastName, age, (Gender)Enum.Parse(typeof(Gender), gender), email, new WinRate(wins, loses));
                }
            } finally
            {
                Disconnect();
            }

            return user;
        }

        public void RegisterUser(User user)
        {
            Connect();

            string sql = "INSERT INTO synth_user (`username`, `password`,`first_name`,`last_name`, `age`, `gender`, `email`, `wins`, `loses`) VALUES (@username, @password, @firstName, @lastName, @age, @gender, @email, @wins, @loses)";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@username", user.UserName);
            Cmd.Parameters.AddWithValue("@password", user.Password);
            Cmd.Parameters.AddWithValue("@firstName", user.FirstName);
            Cmd.Parameters.AddWithValue("@lastName", user.LastName);
            Cmd.Parameters.AddWithValue("@age", user.Age);
            Cmd.Parameters.AddWithValue("@gender", user.Gender.ToString());
            Cmd.Parameters.AddWithValue("@email", user.Email);
            Cmd.Parameters.AddWithValue("@wins", user.WinRate.Wins);
            Cmd.Parameters.AddWithValue("@loses", user.WinRate.Loses);

            try
            {
                Cmd.ExecuteNonQuery();
            } catch (MySqlException)
            {
                //do custom exception passings
            } finally
            {
                Disconnect();
            }
        }

        public User ReturnUserByUsername(string username)
        {
            User user = null;
            Connect();

            string sql = "SELECT * FROM synth_user WHERE username = @username";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@username", username);

            try
            {
                Reader = Cmd.ExecuteReader();

                if (Reader.Read())
                {
                    int id = Reader.GetInt32(0);
                    string username1 = Reader.GetString(1);
                    string password = Reader.GetString(2);
                    string firstName = Reader.GetString(3);
                    string lastName = Reader.GetString(4);
                    int age = Reader.GetInt32(5);
                    string gender = Reader.GetString(6);
                    string email = Reader.GetString(7);

                    user = new User(id, username1, password, firstName, lastName, age, (Gender)Enum.Parse(typeof(Gender), gender), email, new WinRate(Reader.GetInt32(8), Reader.GetInt32(9)));
                }
            } catch (Exception ex)
            {

            } finally
            {
                Disconnect();
            }

            return user;
        }

        public void UpdateUsersWinrate(List<User> players)
        {
            Connect();

            string sql = "UPDATE synth_user SET wins = @wins, loses = @loses WHERE id = @id";

            try
            {
                foreach (var player in players)
                {
                    Cmd = new MySqlCommand(sql, Con);
                    Cmd.Parameters.AddWithValue("@wins", player.WinRate.Wins);
                    Cmd.Parameters.AddWithValue("@loses", player.WinRate.Loses);
                    Cmd.Parameters.AddWithValue("@id", player.Id);
                    Cmd.ExecuteNonQuery();
                }
            } finally
            {
                Disconnect();
            }
        }

        public bool UsernameTaken(string username)
        {
            bool taken = false;

            Connect();

            string sql = "SELECT * FROM synth_user WHERE username = @username";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@username", username);

            try
            {
                Reader = Cmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    taken = true;
                }
            } finally
            {
                Disconnect();
            }

            return taken;
        }

        public bool EmailAlreadyRegistered(string email)
        {
            bool taken = false;

            Connect();

            string sql = "SELECT * FROM synth_user WHERE email = @email";
            Cmd = new MySqlCommand(sql, Con);
            Cmd.Parameters.AddWithValue("@email", email);

            try
            {
                Reader = Cmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    taken = true;
                }
            } finally
            {
                Disconnect();
            }

            return taken;
        }
    }
}

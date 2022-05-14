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

        public User CheckUserCredentials(string username, string password)
        {
            User user = null;
            Connect();

            string sql = "SELECT * FROM synth_staff WHERE username = @username AND password = @password";
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
                    string email = Reader.GetString(5);

                    user = new User(id, userName, password1, firstName, lastName, email);
                }
            } finally
            {
                Disconnect();
            }

            return user;
        }
    }
}

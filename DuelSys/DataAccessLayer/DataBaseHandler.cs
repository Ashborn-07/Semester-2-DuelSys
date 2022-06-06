using MySql.Data.MySqlClient;
using LogicLayer;

namespace DataAccessLayer
{
    public abstract class DataBaseHandler
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataReader reader;

        protected string path;

        public DataBaseHandler(string path)
        {
            this.path = path;
        }

        protected MySqlConnection Con { get { return con; } }
        protected MySqlCommand Cmd { get { return cmd; } set { cmd = value; } }
        protected MySqlDataReader Reader { get { return reader; } set { reader = value; } }

        protected void Connect()
        {
            //"Server=studmysql01.fhict.local;Uid=dbi482834;Database=dbi482834;Pwd=Syrux79;Allow User Variables=True"
            if (con == null)
            {
                con = new MySqlConnection(path);
                try
                {
                    con.Open();
                } catch (MySqlException)
                {
                    Disconnect();
                    throw new ConnectionException("Cannot connect to server");
                }
            }
        }

        protected void Disconnect()
        {
            if (con.State == System.Data.ConnectionState.Open && con != null)
            {
                con.Close();
                con = null;
            }
        }
    }
}
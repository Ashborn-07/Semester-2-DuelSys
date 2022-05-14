using MySql.Data.MySqlClient;

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

        public MySqlConnection Con { get { return con; } }
        public MySqlCommand Cmd { get { return cmd; } set { cmd = value; } }
        public MySqlDataReader Reader { get { return reader; } set { reader = value; } }

        public void Connect()
        {
            //"Server=studmysql01.fhict.local;Uid=dbi482834;Database=dbi482834;Pwd=Syrux79;Allow User Variables=True"
            if (con == null)
            {
                con = new MySqlConnection(path);
                con.Open();
            }
        }

        public void Disconnect()
        {
            if (con.State == System.Data.ConnectionState.Open && con != null)
            {
                con.Close();
                con = null;
            }
        }
    }
}
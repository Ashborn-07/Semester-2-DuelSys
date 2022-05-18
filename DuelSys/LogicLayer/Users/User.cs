namespace LogicLayer
{
    public class User
    {
        protected int id;
        protected string username;
        protected string password;
        protected string firstName;
        protected string lastName;
        protected string email;

        public int Id { get { return this.id; } }
        public string UserName { get { return this.username; } set { this.username = value; } }
        public string Password { get { return this.password; } }
        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }
        public string LastName { get { return this.lastName; } set { this.lastName = value; } }
        public string Email { get { return this.email; } set { this.email = value; } }
    

        public User(string username, string password, string firstName, string lastName, string email)
        {
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }

        public User(int id, string username, string password, string firstName, string lastName, string email)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }
    }
}
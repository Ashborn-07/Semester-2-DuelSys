namespace LogicLayer
{
    public class User
    {
        private int id;
        private string username;
        private string password;
        private string firstName;
        private string lastName;
        private int age;
        private Gender gender;
        private string email;
        private WinRate winRate;

        public WinRate WinRate { get { return this.winRate; } set { this.winRate = value; } }
        public int Id { get { return this.id; } }
        public string UserName { get { return this.username; } set { this.username = value; } }
        public string Password { get { return this.password; } }
        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }
        public string LastName { get { return this.lastName; } set { this.lastName = value; } }
        public int Age { get { return this.age; } set { this.age = value; } }
        public Gender Gender { get { return this.gender; } set { this.gender = value; } }
        public string Email { get { return this.email; } set { this.email = value; } }
    

        public User(string username, string password, string firstName, string lastName, int age, Gender gender, string email, WinRate winRate)
        {
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.gender = gender;
            this.email = email;
            this.winRate = winRate;
        }

        public User(int id, string username, string password, string firstName, string lastName, int age, Gender gender, string email, WinRate winRate)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.gender = gender;
            this.email = email;
            this.winRate = winRate;
        }

        public User(int id, string username, string firstName, string lastName, int age, Gender gender, string email, WinRate winRate) 
        {
            this.id = id;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.gender = gender;
            this.email = email;
            this.winRate = winRate;
        }
    }
}
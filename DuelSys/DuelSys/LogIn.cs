using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using LogicLayer;
using System.Configuration;


namespace DuelSys
{
    public partial class LogIn : Form
    {
        private User user;
        private UserService service;

        public LogIn()
        {
            InitializeComponent();
            IUserRepository repository = new UserRepository(ConfigurationManager.ConnectionStrings["phpma"].ConnectionString);
            service = new UserService(repository);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbUsername.Text) || String.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                user = service.CheckUserCredentials(tbUsername.Text, tbPassword.Text);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (user == null)
            {
                MessageBox.Show("Incorrect username or password.");
                return;
            }

            Menu menu = new Menu(user);
            menu.Show();
            this.Close();
        }
    }
}

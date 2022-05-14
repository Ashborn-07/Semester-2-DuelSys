using LogicLayer;
using DataAccessLayer;

namespace DuelSys
{
    public partial class Menu : Form
    {
        private User user;

        public Menu(User user)
        {
            InitializeComponent();
            this.user = user;
        }
    }
}
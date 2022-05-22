using LogicLayer;
using DataAccessLayer;
using System.Drawing;

namespace DuelSys
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnTournament_Click(object sender, EventArgs e)
        {
            ColorRessetter();
            flpMain.Controls.Clear();
            flpMain.Controls.Add(new UserControlTournament());
            btnTournament.BackColor = ColorTranslator.FromHtml("#007F97");
            picBoxCup.BackColor = ColorTranslator.FromHtml("#007F97");
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ColorRessetter();
            flpMain.Controls.Clear();
            //
            btnSchedule.BackColor = ColorTranslator.FromHtml("#007F97");
            picboxCalendar.BackColor = ColorTranslator.FromHtml("#007F97");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorRessetter();
            flpMain.Controls.Clear();
            //
            button3.BackColor = ColorTranslator.FromHtml("#007F97");
            //picBoxCup.BackColor = ColorTranslator.FromHtml("#007F97");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ColorRessetter();
            flpMain.Controls.Clear();
            //
            btnSettings.BackColor = ColorTranslator.FromHtml("#007F97");
            picBoxSettings.BackColor = ColorTranslator.FromHtml("#007F97");
        }

        private void ColorRessetter()
        {
            btnTournament.BackColor = ColorTranslator.FromHtml("#6036F5");
            picBoxCup.BackColor = ColorTranslator.FromHtml("#6036F5");
            btnSchedule.BackColor = ColorTranslator.FromHtml("#6036F5");
            picboxCalendar.BackColor = ColorTranslator.FromHtml("#6036F5");
            btnSettings.BackColor = ColorTranslator.FromHtml("#6036F5");
            picBoxSettings.BackColor = ColorTranslator.FromHtml("#6036F5");
            button3.BackColor = ColorTranslator.FromHtml("#6036F5");
        }
    }
}
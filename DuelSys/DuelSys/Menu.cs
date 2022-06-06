using LogicLayer;
using DataAccessLayer;
using System.Drawing;

namespace DuelSys
{
    public partial class Menu : Form
    {
        private Form currentChildForm;
        public Menu()
        {
            InitializeComponent();
        }

        private void btnTournament_Click(object sender, EventArgs e)
        {
            ColorRessetter();
            panelForm.Controls.Clear();
            OpenChildForm(new TournamentForm(this));
            panelForm.Controls.Add(currentChildForm);
            btnTournament.BackColor = ColorTranslator.FromHtml("#007F97");
            picBoxCup.BackColor = ColorTranslator.FromHtml("#007F97");
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ColorRessetter();
            panelForm.Controls.Clear();
            OpenChildForm(new ScheduleForm(this));
            btnSchedule.BackColor = ColorTranslator.FromHtml("#007F97");
            picboxCalendar.BackColor = ColorTranslator.FromHtml("#007F97");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ColorRessetter();
            panelForm.Controls.Clear();
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
        }

        private void OpenChildForm(Form form)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelForm.Controls.Add(form);
            panelForm.Tag = form;
            form.BringToFront();
            form.Show();
            //lbTitle.Text = form.Text;
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
        }

        public void Alert(string msg, enmType type)
        {
            Notification frm = new Notification();
            frm.showAlert(msg, type);
        }
    }
}
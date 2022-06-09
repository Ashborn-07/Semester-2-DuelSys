using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using LogicLayer;

namespace DuelSys
{
    public partial class ConfirmationForm : Form
    {
        private bool valid = false;
        private Tournament tournament;
        private TournamentService service;
        private TournamentInformation tournamentInformation;

        public ConfirmationForm(Tournament tournament, TournamentService service, TournamentInformation tournamentInformation)
        {
            InitializeComponent();
            this.tournament = tournament;
            this.service = service;
            this.tournamentInformation = tournamentInformation;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbConfirmation.Text))
            {
                MessageBox.Show("Input field is empty!");
            }

            if (tbConfirmation.Text.All(c => char.IsUpper(c)))
            {
                if (tbConfirmation.Text.Equals("DELETE"))
                {
                    valid = true;
                }
            }

            if (valid)
            {
                service.DeleteTournament(tournament.Id);
            }

            this.Close();
        }

        private void ConfirmationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Alert("Tournament deleted successfully", enmType.Success);
            tournamentInformation.Close();
        }

        public void Alert(string msg, enmType type)
        {
            Notification frm = new Notification();
            frm.showAlert(msg, type);
        }
    }
}

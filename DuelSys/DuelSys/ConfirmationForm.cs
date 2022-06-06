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

        public ConfirmationForm(Tournament tournament, TournamentService service)
        {
            InitializeComponent();
            this.tournament = tournament;
            this.service = service;
        }

        private void ConfirmationForm_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbConfirmation.Text))
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
        }
    }
}

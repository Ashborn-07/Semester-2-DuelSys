using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using LogicLayer;
using DataAccessLayer;

namespace DuelSys
{
    public partial class UserControlTournament : UserControl
    {
        private Tournament tournament;

        public UserControlTournament(Tournament tournament)
        {
            InitializeComponent();
            this.tournament = tournament;
        }

        private void UserControlTournament_Load(object sender, EventArgs e)
        {
            lblTournamentId.Text = lblTournamentId.Text + tournament.Id;
            lblTournamentName.Text = tournament.Name;
            lblSport.Text = lblSport.Text + tournament.Sport.Name;
            lblStartTime.Text = lblStartTime.Text + tournament.Time.Start.ToString("d/M/yyyy");
            lblEndTime.Text = lblEndTime.Text + tournament.Time.End.ToString("d/M/yyyy");
        }

        private void UserControlTournament_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}

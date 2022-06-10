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
    public partial class UserControlScheduleTournament : UserControl
    {
        private Tournament tournament;
        private TournamentService service;

        public UserControlScheduleTournament(Tournament tournament)
        {
            InitializeComponent();

            this.tournament = tournament;

            ITournamentRepository repository = new TournamentRepository(ConfigurationManager.
                ConnectionStrings["phpma"].ToString());
            service = new TournamentService(repository);
        }

        private void UserControlScheduleTournament_Load(object sender, EventArgs e)
        {
            lblTournamentId.Text = lblTournamentId.Text + tournament.Id;
            lblTournamentName.Text = tournament.Name;
            lblSport.Text = lblSport.Text + tournament.Sport.Name;
            lblStartTime.Text = lblStartTime.Text + tournament.Time.Start.ToString("d/M/yyyy");
            lblEndTime.Text = lblEndTime.Text + tournament.Time.End.ToString("d/M/yyyy");

            int count = 0;

            try
            {
                count = service.PlayerCountOfTournament(tournament.Id);
            }
            catch (ConnectionException ex)
            {
                Alert(ex.Message, enmType.Error);
            }

            lblRegisteredPlayers.Text = lblRegisteredPlayers.Text + count;
        }

        public void Alert(string msg, enmType type)
        {
            Notification frm = new Notification();
            frm.showAlert(msg, type);
        }

        private void UserControlScheduleTournament_Click(object sender, EventArgs e)
        {
            MatchesForm matchesForm = new MatchesForm(tournament, service);
            matchesForm.ShowDialog();
        }
    }
}

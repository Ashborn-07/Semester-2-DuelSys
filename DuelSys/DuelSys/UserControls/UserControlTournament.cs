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
        private TournamentService service;
        private TournamentForm tournamentForm;

        public UserControlTournament(Tournament tournament, TournamentForm tournamentForm)
        {
            InitializeComponent();
            this.tournament = tournament;

            ITournamentRepository repository = new TournamentRepository(ConfigurationManager.ConnectionStrings["phpma"].ToString());
            service = new TournamentService(repository);

            this.tournamentForm = tournamentForm;
        }

        private void UserControlTournament_Load(object sender, EventArgs e)
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
            } catch (ConnectionException ex)
            {
                Alert(ex.Message, enmType.Error);
            }

            lblRegisteredPlayers.Text = lblRegisteredPlayers.Text + count;
        }

        private void UserControlTournament_DoubleClick(object sender, EventArgs e)
        {
            TournamentInformation information = new TournamentInformation(tournament, tournamentForm);
            information.ShowDialog();
        }

        public void Alert(string msg, enmType type)
        {
            Notification frm = new Notification();
            frm.showAlert(msg, type);
        }
    }
}

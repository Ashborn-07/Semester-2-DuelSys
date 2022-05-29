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
    public partial class TournamentInformation : Form
    {
        private TournamentService service;
        private Tournament tournament;

        public TournamentInformation(Tournament tournament)
        {
            InitializeComponent();

            ITournamentRepository tournamentRepository = new TournamentRepository(ConfigurationManager.
                ConnectionStrings["phpma"].ToString());
            service = new TournamentService(tournamentRepository);

            this.tournament = tournament;
        }

        private void TournamentInformation_Load(object sender, EventArgs e)
        {
            try
            {
                dgvPlayers.DataSource = service.ListOfUsersOfTournament(tournament.Id);
            } catch (ConnectionException ex)
            {
                Alert(ex.Message, enmType.Error);
            } catch (Exception ex)
            {
                Alert(ex.Message, enmType.Warning);
            }
        }

        public void Alert(string msg, enmType type)
        {
            Notification frm = new Notification();
            frm.showAlert(msg, type);
        }
    }
}

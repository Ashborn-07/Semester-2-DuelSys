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
    public partial class TournamentForm : Form
    {
        private TournamentService service;
        private Menu menu;

        public TournamentForm(Menu menu)
        {
            InitializeComponent();
            ITournamentRepository repository = new TournamentRepository(ConfigurationManager.ConnectionStrings["phpma"].ToString());
            service = new TournamentService(repository);
            this.menu = menu;
        }

        private void Tournament_Load(object sender, EventArgs e)
        {
            LoadTournaments();
        }

        public void LoadTournaments()
        {
            flPanelTournament.Controls.Clear();
            List<Tournament> tournaments;

            try
            {
                tournaments = service.GetTournaments();
            }
            catch (ConnectionException ex)
            {
                Alert(ex.Message, enmType.Error);
                return;
            }

            if (tournaments.Count > 0)
            {
                foreach (var tournament in tournaments)
                {
                    flPanelTournament.Controls.Add(new UserControlTournament(tournament, this));
                }
            }
        }

        private void btnCreateTournament_Click(object sender, EventArgs e)
        {
            CreateTournament createTournament = new CreateTournament(this);
            createTournament.ShowDialog();
        }

        public void Alert(string msg, enmType type)
        {
            Notification frm = new Notification();
            frm.showAlert(msg, type);
        }
    }
}

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
    public partial class ScheduleForm : Form
    {
        private TournamentService service;
        private Menu menu;

        public ScheduleForm(Menu menu)
        {
            InitializeComponent();
            this.menu = menu;

            ITournamentRepository repository = new TournamentRepository(ConfigurationManager.ConnectionStrings["phpma"].ToString());
            service = new TournamentService(repository);
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            LoadTournaments();
        }

        public void LoadTournaments()
        {
            flPanelTournamentSchedule.Controls.Clear();
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
                    flPanelTournamentSchedule.Controls.Add(new UserControlScheduleTournament(tournament));
                }
            }
        }

        public void Alert(string msg, enmType type)
        {
            Notification frm = new Notification();
            frm.showAlert(msg, type);
        }
    }
}

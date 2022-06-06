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
    public partial class CreateTournament : Form
    {
        private TournamentService service;
        private TournamentForm tournamentForm;

        public CreateTournament(TournamentForm tournamentForm)
        {
            InitializeComponent();
            ITournamentRepository repository = new TournamentRepository(ConfigurationManager.ConnectionStrings["phpma"].ToString());
            service = new TournamentService(repository);
            this.tournamentForm = tournamentForm;
        }

        private void CreateTournament_Load(object sender, EventArgs e)
        {
            cbSport.Items.Clear();
            List<string> sports;

            try
            {
                sports = service.GetListOfSports();
            }
            catch (ConnectionException ex)
            {
                Alert(ex.Message, enmType.Error);
                return;
            }

            foreach (var sport in sports)
            {
                cbSport.Items.Add(sport);
            }
        }

        private void btnCreateTournament_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbTournamentName.Text) && String.IsNullOrEmpty(tbLocation.Text) && String.IsNullOrEmpty(tbDescription.Text))
            {
                Alert("All fields must be filled", enmType.Warning);
                return;
            }

            DateTime start = dTimeStart.Value;
            DateTime end = dTimeEnd.Value;

            Tournament tournament = new Tournament(tbTournamentName.Text, tbDescription.Text, tbLocation.Text,
                GetSportObject(), new TournamentTime(start, end),
                cbSystem.SelectedItem.ToString(), Convert.ToInt32(numMaxPlayers.ValueNumber), Convert.ToInt32(numMinPlayers.ValueNumber));

            try
            {
                service.CreateTournament(tournament);
            }
            catch (Exception ex)
            {
                Alert(ex.Message, enmType.Error);
                return;
            }

            Alert("Success in creating tournament", enmType.Success);

            this.Close();
        }

        public void Alert(string msg, enmType type)
        {
            Notification frm = new Notification();
            frm.showAlert(msg, type);
        }

        private void CreateTournament_FormClosing(object sender, FormClosingEventArgs e)
        {
            tournamentForm.LoadTournaments();
        }

        private Sport GetSportObject()
        {
            switch (cbSport.SelectedIndex)
            {
                case 0:
                    return new Basketball(cbSport.SelectedIndex + 1, cbSport.SelectedItem.ToString());
                case 1:
                    return new Football(cbSport.SelectedIndex + 1, cbSport.SelectedItem.ToString());
                case 2:
                    return new Badminton(cbSport.SelectedIndex + 1, cbSport.SelectedItem.ToString());
                case 3:
                    return new LeagueOfLegends(cbSport.SelectedIndex + 1, cbSport.SelectedItem.ToString());
                default:
                    return new Badminton(cbSport.SelectedIndex + 1, cbSport.SelectedItem.ToString());
            }
        }

        private void dTimeStart_ValueChanged(object sender, EventArgs e)
        {
            dTimeEnd.Value = dTimeStart.Value;
        }
    }
}

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
    public partial class MatchesForm : Form
    {
        private MatchService matchService;
        private TournamentService tournamentService;
        private Tournament tournament;
        List<Match> matches = new List<Match>();
        bool valid = true;

        public MatchesForm(Tournament tournament, TournamentService tournamentService)
        {
            InitializeComponent();
            this.tournamentService = tournamentService;
            this.tournament = tournament;
            this.Text = $"{tournament.Name} - {tournament.Sport.Name}";

            IMatchRepository matchRepository = new MatchRepository(ConfigurationManager.
                ConnectionStrings["phpma"].ToString());
            matchService = new MatchService(matchRepository);
        }

        private void MatchesForm_Load(object sender, EventArgs e)
        {
            DisplayMatches();
        }

        public void Alert(string msg, enmType type)
        {
            Notification frm = new Notification();
            frm.showAlert(msg, type);
        }

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                matchService.CreateSchedule(tournament);
            }
            catch (ConnectionException ex)
            {
                Alert(ex.Message, enmType.Error);
                return;
            }
            catch (MatchesException ex)
            {
                Alert(ex.Message, enmType.Warning);
                return;
            }

            DisplayMatches();
        }

        public void DisplayMatches()
        {
            dgvMatches.Rows.Clear();

            matches = new List<Match>();

            try
            {
                matches = matchService.GetMatches(tournament);
            }
            catch (ConnectionException ex)
            {
                Alert(ex.Message, enmType.Error);
                valid = false;
            }
            catch (MatchesException ex)
            {
                Alert(ex.Message, enmType.Info);
                valid = false;
            }

            if (valid)
            {
                dgvMatches.ColumnCount = 6;
                dgvMatches.Columns[0].Name = "Match Id";
                dgvMatches.Columns[1].Name = "Player 1";
                dgvMatches.Columns[2].Name = "Player 2";
                dgvMatches.Columns[3].Name = "Player 1 Score";
                dgvMatches.Columns[4].Name = "Player 2 Score";
                dgvMatches.Columns[5].Name = "Date";

                int i = 0;

                foreach (var match in matches)
                {
                    string[] row = new string[] { $"{match.Id}", $"{match.Player1.UserName}", $"{match.Player2.UserName}", $"{match.Scores[0]}", $"{match.Scores[1]}", $"{match.Date.ToString("d")}" };
                    dgvMatches.Rows.Add(row);

                    if (match.Winner != 0)
                    {
                        if (match.Winner == match.Player1.Id)
                        {
                            dgvMatches.Rows[i].Cells[1].Style.BackColor = Color.Green;
                            dgvMatches.Rows[i].Cells[2].Style.BackColor = Color.Red;
                        }
                        if (match.Winner == match.Player2.Id)
                        {
                            dgvMatches.Rows[i].Cells[1].Style.BackColor = Color.Red;
                            dgvMatches.Rows[i].Cells[2].Style.BackColor = Color.Green;
                        }
                    }

                    i++;
                }

                btnCreateSchedule.Enabled = false;
                btnCreateSchedule.Visible = false;
            }
        }

        private void btnUpdateScore_Click(object sender, EventArgs e)
        {
            Match match = GetSelectedMatch();

            if (match == null)
            {
                Alert("Select a match!", enmType.Warning);
                return;
            }

            ScoreForm scoreForm = new ScoreForm(match, matchService, this);
            scoreForm.ShowDialog();
        }

        private Match GetSelectedMatch()
        {
            int matchId = Convert.ToInt32(dgvMatches.SelectedRows[0].Cells[0].Value);

            foreach (var match in matches)
            {
                if (match.Id == matchId)
                {
                    return match;
                }
            }

            return null;
        }
    }
}

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
    public partial class ScoreForm : Form
    {
        private Match match;
        private MatchService matchService;
        private MatchesForm form;

        public ScoreForm(Match match, MatchService matchService, MatchesForm form)
        {
            InitializeComponent();
            
            this.match = match;
            this.matchService = matchService;
            this.form = form;
            this.Text = $"Match № {match.Id}";
        }

        private void ScoreForm_Load(object sender, EventArgs e)
        {
            lblPlayer1.Text = $"{match.Player1.UserName} Score:";
            lblPlayer2.Text = $"{match.Player2.UserName} Score:";

            switch (match.Tournament.Sport)
            {
                case Badminton:
                    numScorePlayer1.Maximum = 30;
                    numScorePlayer2.Maximum = 30;
                    break;
                case Basketball:
                    numScorePlayer1.Maximum = 44;
                    numScorePlayer2.Maximum = 44;
                    break;
                case Football:
                    numScorePlayer1.Maximum = 7;
                    numScorePlayer2.Maximum = 7;
                    break;
                case LeagueOfLegends:
                    numScorePlayer1.Maximum = 3;
                    numScorePlayer2.Maximum = 3;
                    break;
                default:
                    break;
            }
        }

        private void btnUpdateScore_Click(object sender, EventArgs e)
        {
            int player1Score = Convert.ToInt32(numScorePlayer1.Value);
            int player2Score = Convert.ToInt32(numScorePlayer2.Value);

            int[] score = new int[2] { player1Score, player2Score };
            match.Scores = score;

            IUserRepository userRepository = new UserRepository(ConfigurationManager.ConnectionStrings["phpma"].ToString());

            try
            {
                matchService.UpdateScore(match, userRepository);
            } catch (Exception ex)
            {
                Alert(ex.Message, enmType.Warning);
                return;
            }

            Alert("Successfully updated", enmType.Success);
            this.Close();
        }

        public void Alert(string msg, enmType type)
        {
            Notification frm = new Notification();
            frm.showAlert(msg, type);
        }

        private void ScoreForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.DisplayMatches();
        }
    }
}

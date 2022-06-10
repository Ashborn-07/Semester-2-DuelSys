using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer;
using DataAccessLayer;

namespace DuelSysWeb.Pages
{
    public class ScheduleModel : PageModel
    {
        public List<Match> matches;
        public List<Tournament> tournaments;
        public DateTime oldDate { get; set; } = DateTime.Now;
        private MatchService matchService;
        private TournamentService tournamentService;
        private IConfiguration configuration;

        public ScheduleModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void OnGet()
        {
            ITournamentRepository repository = new TournamentRepository(configuration.GetConnectionString("MyConn"));
            tournamentService = new TournamentService(repository);

            tournaments = tournamentService.GetTournaments();

            IMatchRepository matchRepository = new MatchRepository(configuration.GetConnectionString("MyConn"));
            matchService = new MatchService(matchRepository);

            matches = new List<Match>();

            foreach (var tournament in tournaments)
            {
                List<Match> listOfMatches = new List<Match>();

                try
                {
                    listOfMatches = matchService.GetMatches(tournament);
                } catch (MatchesException ex)
                {
                    
                }

                foreach (var match in listOfMatches)
                {
                    matches.Add(match);
                }
            }
        }

        protected void Tournament_Click(object sender, EventArgs e)
        {

        }
    }
}

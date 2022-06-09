using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer;
using DataAccessLayer;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace DuelSysWeb.Pages
{
    public class SingleTournamentModel : PageModel
    {
        private TournamentService tournamentService;
        private MatchService matchService;
        public Tournament tournament;
        public List<User> players;
        private IConfiguration configuration;
        private IToastifyService toastify;

        public SingleTournamentModel(IConfiguration configuration, IToastifyService toastify)
        {
            this.configuration = configuration;
            this.toastify = toastify;
        }

        public void OnGet(int id)
        {
            ITournamentRepository tournamentRepository = new TournamentRepository(configuration.GetConnectionString("MyConn"));
            tournamentService = new TournamentService(tournamentRepository);
            IMatchRepository matchRepository = new MatchRepository(configuration.GetConnectionString("MyConn"));
            matchService = new MatchService(matchRepository);

            try
            {
                tournament = tournamentService.GetTournamentById(id);
            } catch (ConnectionException ex)
            {
                toastify.Error(ex.Message);
            } catch (TournamentException ex)
            {
                toastify.Warning(ex.Message);
            }

            try
            {
                players = matchService.GetLeaderBoardOfTournament(tournament);
            } catch (ConnectionException ex)
            {
                toastify.Error(ex.Message);
            } catch (TournamentException ex)
            {
                toastify.Warning(ex.Message);
            }
        }
    }
}

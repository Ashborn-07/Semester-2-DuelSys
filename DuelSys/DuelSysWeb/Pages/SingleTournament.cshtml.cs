using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer;
using DataAccessLayer;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace DuelSysWeb.Pages
{
    public class SingleTournamentModel : PageModel
    {
        private TournamentService service;
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
            ITournamentRepository repository = new TournamentRepository(configuration.GetConnectionString("MyConn"));
            service = new TournamentService(repository);

            try
            {
                tournament = service.GetTournamentById(id);
            } catch (ConnectionException ex)
            {
                toastify.Error(ex.Message);
            } catch (TournamentException ex)
            {
                toastify.Warning(ex.Message);
            }

            try
            {
                players = service.GetLeaderBoardOfTournament(tournament, new MatchRepository(configuration.GetConnectionString("MyConn")));
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

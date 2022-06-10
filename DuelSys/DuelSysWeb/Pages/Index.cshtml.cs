using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using LogicLayer;
using DataAccessLayer;

namespace DuelSysWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IConfiguration configuration;
        private IToastifyService toastify;

        public List<Tournament> tournaments;
        private TournamentService tournamentService;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IToastifyService toastify)
        {
            _logger = logger;
            this.configuration = configuration;
            this.toastify = toastify;

            ITournamentRepository repository = new TournamentRepository(configuration.GetConnectionString("MyConn"));
            tournamentService = new TournamentService(repository);

            try
            {
                tournaments = tournamentService.GetAllStartedTournaments();
            } catch (ConnectionException ex)
            {
                toastify.Error(ex.Message);
            } catch (TournamentException ex)
            {
                toastify.Information(ex.Message);
            }
        }

        public void OnGet()
        {

        }
    }
}
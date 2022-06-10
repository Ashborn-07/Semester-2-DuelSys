using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using LogicLayer;
using DataAccessLayer;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace DuelSysWeb.Pages
{
    [Authorize]
    public class TournamentPageModel : PageModel
    {
        public DateTime OldYear;
        public TournamentService service;
        public List<Tournament> tournaments;
        private IConfiguration configuration;
        private readonly IToastifyService toastify;

        [BindProperty]
        public string buttonType { get; set; }
        
        [BindProperty(SupportsGet =true)]
        public int TournamentId { get; 
            set; }

        public TournamentPageModel(IConfiguration configuration, IToastifyService toastify)
        {
            this.configuration = configuration;
            this.toastify = toastify;
        }

        public void OnGet()
        {
            ITournamentRepository repository = new TournamentRepository(configuration.GetConnectionString("MyConn"));
            service = new TournamentService(repository);

            try
            {
                tournaments = service.GetTournaments();
            } catch (Exception ex)
            {
                toastify.Error(ex.Message);
            }
        }

        public IActionResult OnPost()
        {
            var tour = TournamentId;
            ITournamentRepository repository = new TournamentRepository(configuration.GetConnectionString("MyConn"));
            service = new TournamentService(repository);

            var id = User.Claims.Where(c => c.Type == "id")
                   .Select(c => c.Value).SingleOrDefault();

            try
            {
                switch (buttonType)
                {
                    case "participate":
                        service.RegisterPlayer(tour, Convert.ToInt32(id));
                        toastify.Success("Successfully registered for the tournament", 3);
                        break;
                    case "cancel":
                        service.CancelRegistrationTournament(tour, Convert.ToInt32(id));
                        toastify.Success("Successfully canceled the registration for the tournament", 3);
                        break;
                    default:
                        break;
                }
            } catch (MatchesException ex)
            {
                toastify.Warning(ex.Message);
            } catch (ConnectionException ex)
            {
                toastify.Error(ex.Message);
            } catch (Exception ex)
            {
                toastify.Information(ex.Message);
            }

            return RedirectToPage("TournamentPage");
        }

        public bool AlreadyRegistered(int tournamentId)
        {
            bool registered = false;

            ITournamentRepository repository = new TournamentRepository(configuration.GetConnectionString("MyConn"));
            service = new TournamentService(repository);

            var id = User.Claims.Where(c => c.Type == "id")
                   .Select(c => c.Value).SingleOrDefault();


            if (service.PleyerAlreadyRegistered(tournamentId, Convert.ToInt32(id)))
            {
                registered = true;
            }

            return registered;
        }
    }
}

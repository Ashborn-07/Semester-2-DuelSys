using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer;
using DataAccessLayer;

namespace DuelSysWeb.Pages
{
    public class TournamentPageModel : PageModel
    {
        public DateTime OldYear;
        private TournamentService service;
        public List<Tournament> tournaments;
        private IConfiguration configuration;

        [BindProperty]
        public string buttonType { get; set; }
        
        [BindProperty]
        public int TournamentId { get; set; }

        public TournamentPageModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void OnGet()
        {
            ITournamentRepository repository = new TournamentRepository(configuration.GetConnectionString("MyConn"));
            service = new TournamentService(repository);

            tournaments = service.GetTournaments();
        }

        public IActionResult OnPost()
        {
            ITournamentRepository repository = new TournamentRepository(configuration.GetConnectionString("MyConn"));
            service = new TournamentService(repository);

            var id = User.Claims.Where(c => c.Type == "id")
                   .Select(c => c.Value).SingleOrDefault();

            try
            {
                switch (buttonType)
                {
                    case "participate":
                        service.RegisterPlayer(TournamentId, Convert.ToInt32(id));
                        break;
                    case "cancel":
                        service.CancelRegistrationTournament(TournamentId, Convert.ToInt32(id));
                        break;
                    default:
                        break;
                }
            } catch (Exception)
            {

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

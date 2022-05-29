using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer;
using DataAccessLayer;

namespace DuelSysWeb.Pages
{
    public class ScheduleModel : PageModel
    {
        public List<Tournament> tournaments;
        public DateTime oldDate { get; set; } = DateTime.Now;
        private TournamentService service;
        private IConfiguration configuration;

        public ScheduleModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void OnGet()
        {
            ITournamentRepository repository = new TournamentRepository(configuration.GetConnectionString("MyConn"));
            service = new TournamentService(repository);

            tournaments = service.GetTournaments();
        }
    }
}

using DataAccessLayer;
using LogicLayer;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSysWeb.Pages
{
    public class RegisterPageModel : PageModel
    {
        [BindProperty]
        public RegisterModel registerModel { get; set; }
        [BindProperty, Required]
        public string GenderProp { get; set; } = "UNSPECIFIED";
        private UserService service;
        private IConfiguration Configuration;

        public RegisterPageModel(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            IUserRepository repository = new UserRepository(Configuration.GetConnectionString("MyConn"));
            service = new UserService(repository);

            if (ModelState.IsValid)
            {
                User registeredUser = new User(registerModel.Username, registerModel.Password, registerModel.FirstName, registerModel.LastName, registerModel.Age, (Gender)Enum.Parse(typeof(Gender), GenderProp), registerModel.Email, new WinRate(0, 0));

                try
                {
                    service.RegisterUser(registeredUser);
                }
                catch (Exception ex)
                {
                    //show alert
                    //Response.WriteAsJsonAsync();
                    return Page();
                }

                return RedirectToPage("LogInPage");
            }

            return Page();
        }
    }
}

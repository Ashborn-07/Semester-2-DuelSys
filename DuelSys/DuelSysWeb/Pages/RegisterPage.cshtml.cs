using DataAccessLayer;
using LogicLayer;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNetCoreHero.ToastNotification.Abstractions;


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
        private readonly IToastifyService toastify;

        public RegisterPageModel(IConfiguration _configuration, IToastifyService toastify)
        {
            Configuration = _configuration;
            this.toastify = toastify;
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
                catch (ConnectionException ex)
                {
                    toastify.Error(ex.Message, 3);
                    return Page();
                } catch (UserException ex)
                {
                    toastify.Warning(ex.Message, 3);
                    return Page();
                } catch(Exception ex)
                {
                    toastify.Error(ex.Message, 3);
                    return Page();
                }

                toastify.Success("Registered successfully", 3);
                return RedirectToPage("LogInPage");
            }

            return Page();
        }
    }
}

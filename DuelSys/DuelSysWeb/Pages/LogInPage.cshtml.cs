using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer;
using DataAccessLayer;
using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace DuelSysWeb.Pages
{
    public class LogInPageModel : PageModel
    {
        private UserService service;
        [BindProperty]
        public LogInModel logInModel { get; set; }
        private IConfiguration Configuration;
        private IToastifyService toastify;

        public LogInPageModel(IConfiguration _configuration, IToastifyService toastify)
        {
            Configuration = _configuration;
            this.toastify = toastify;
        }

        public void OnGet()
        {
            if (User.Claims != null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }

        public IActionResult OnPost()
        {
            IUserRepository repository = new UserRepository(Configuration.GetConnectionString("MyConn"));
            service = new UserService(repository);

            if (ModelState.IsValid)
            {
                User user;
                try
                {
                    user = service.CheckUserCredentials(logInModel.Username, logInModel.Password);
                } catch(UserException ex)
                {
                    toastify.Error(ex.Message, 3);
                    return Page();
                } catch (Exception ex)
                {
                    toastify.Error(ex.Message, 3);
                    return Page();
                }

                if (user != null)
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims.Add(new Claim("id", user.Id.ToString()));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                    toastify.Success("Logged in successfully", 3);
                    return RedirectToPage("Index");
                }
            }

            toastify.Error("Username must be at least 5 characters long", 3);
            toastify.Error("Password must be at least 6 characters long", 3);

            return Page();
        }
    }
}

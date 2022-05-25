using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer;
using DataAccessLayer;
using System.Security.Claims;

namespace DuelSysWeb.Pages
{
    public class LogInPageModel : PageModel
    {
        private UserService service;
        [BindProperty]
        public LogInModel logInModel { get; set; }
        private IConfiguration Configuration;

        public LogInPageModel(IConfiguration _configuration)
        {
            Configuration = _configuration;
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
                } catch(Exception)
                {
                    return Page();
                }

                if (user != null)
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims.Add(new Claim("id", user.Id.ToString()));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                    return RedirectToPage("Index");
                }
            }

            return Page();
        }
    }
}

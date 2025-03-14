using Microsoft.AspNetCore.Mvc;

namespace Alpha.Webb.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return LocalRedirect("/projects");
            //return View();
        }
    }
}

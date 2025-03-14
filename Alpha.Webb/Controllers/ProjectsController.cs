using Microsoft.AspNetCore.Mvc;

namespace Alpha.Webb.Controllers
{
    [Route("projects")]
    public class ProjectsController : Controller
    {
        [Route("")]
        public IActionResult Projects()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Alpha.Webb.Controllers;

[Route("admin")]
public class AdminController : Controller
{
    [Route("members")]
    public IActionResult Members()
    {
        return View();
    }
}

using Alpha.Webb.ViewModels;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.Webb.Controllers
{

    //[Route("projects")]
    public class ProjectsController : Controller
    {
        [HttpGet("")]
        public IActionResult Projects()
        {
            var formModel = new ProjectFormViewModel();
            return View(formModel);
        }


        [HttpPost("addproject")]
        public IActionResult AddProject(ProjectFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToList()
                    );

                return BadRequest(new { success = false, errors });
            }

            var project = new Project
            {
                ProjectName = model.ProjectName,
                ClientName = model.ClientName,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                CreatedDate = DateTime.Now
            };

            return RedirectToAction("Projects");
        }

        [HttpPost("editproject")]
        public IActionResult EditProject(ProjectFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                   .Where(x => x.Value?.Errors.Count > 0)
                   .ToDictionary(
                       kvp => kvp.Key,
                       kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToList()
                   );

                return BadRequest(new { success = false, errors });
            }

            return RedirectToAction("Projects");
        }
    }
}

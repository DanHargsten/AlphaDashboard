using Alpha.Webb.ViewModels;
using Business.Models;
using Business.Services;
using Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alpha.Webb.Controllers
{


    public class ProjectsController(AppDbContext context, ProjectService projectService) : Controller
    {
        private readonly AppDbContext _context = context;
        private readonly ProjectService _projectService = projectService;




        // Projects()
        [HttpGet("")]
        public async Task<IActionResult> Projects()
        {
            var projects = await _context.Projects.ToListAsync();
            var viewModel = new ProjectsPageViewModel()
            {
                NewProject = new ProjectFormViewModel(),
                Projects = projects
            };

            // Send to service

            return View(viewModel);
        }





        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectFormViewModel model)
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


            var projectForm = new ProjectRegistrationForm
            {
                ProjectName = model.ProjectName,
                ClientName = model.ClientName,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
            };

            var result = await _projectService.AddProjectAsync(projectForm);
            return Ok(new { success = result });
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

            return Ok(new { success = true });
        }
    }
}

using Business.Factories;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository)
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<bool> AddProjectAsync(ProjectRegistrationForm form)
    {
        try
        {
            var project = ProjectFactory.CreateFromForm(form);
            var entity = ProjectFactory.CreateEntity(project);

            await _projectRepository.AddAsync(entity);
            
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in ProjectService: {ex.Message}");
            return false;
        }
    }
}
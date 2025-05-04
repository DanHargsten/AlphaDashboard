using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static Project CreateFromForm(ProjectRegistrationForm form)
    {
        return new Project
        {
            ProjectName = form.ProjectName,
            ClientName = form.ClientName,
            Description = form.Description,
            StartDate = form.StartDate,
            EndDate = form.EndDate,
            CreatedDate = DateTime.UtcNow
        };
    }

    public static ProjectEntity CreateEntity(Project model)
    {
        return new ProjectEntity
        {
            ProjectName = model.ProjectName,
            ClientName = model.ClientName,
            Description = model.Description,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            CreatedDate = model.CreatedDate,
            ImagePath = model.ImagePath
        };
    }
}
namespace Alpha.Webb.ViewModels
{
    public class ProjectsPageViewModel
    {
        public IEnumerable<Data.Entities.ProjectEntity> Projects { get; set; } = [];
        public ProjectFormViewModel NewProject {  get; set; } = new ProjectFormViewModel();
    }
}
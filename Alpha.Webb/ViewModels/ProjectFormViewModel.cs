using System.ComponentModel.DataAnnotations;

namespace Alpha.Webb.ViewModels
{
    public class ProjectFormViewModel
    {
        public int? Id { get; set; }


        [Display(Name = "Project Image", Prompt = "Select an image")]
        [DataType(DataType.Upload)]
        public IFormFile? ProjectImage { get; set; }


        [Display(Name = "Project Name", Prompt = "Project name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Required")]
        public string ProjectName { get; set; } = null!;


        [Display(Name = "Client Name", Prompt = "Client name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Required")]
        public string ClientName { get; set; } = null!;


        [DataType(DataType.Text)]
        public string? Description { get; set; }


        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }


        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }


        public string? ImagePreviewUrl { get; set; }
    }
}

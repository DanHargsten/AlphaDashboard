using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string ProjectName { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string ClientName { get; set; } = null!;

    [MaxLength(500)]
    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public string? ImagePath { get; set; }
}
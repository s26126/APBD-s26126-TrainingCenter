using System.ComponentModel.DataAnnotations;

namespace APBD_s26126_TrainingCenter.Models;

public class Room
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string BuildingCode { get; set; } = null!;
    public int Floor { get; set; }
    [Range(1, int.MaxValue)]
    public int Capacity { get; set; }
    public bool HasProjector { get; set; }
    public bool IsActive { get; set; }
}
namespace APBD_s26126_TrainingCenter.Models;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string BuildingCode { get; set; } = null!;
    public int Floor { get; set; }
    public int Capacity { get; set; }
    public bool HasProjector { get; set; }
    public bool IsActive { get; set; }
}
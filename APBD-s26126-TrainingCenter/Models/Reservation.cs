using System.ComponentModel.DataAnnotations;

namespace APBD_s26126_TrainingCenter.Models;

public class Reservation
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    [Required]
    public string OrganizerName { get; set; } = null!;
    [Required]
    public string Topic { get; set; } = null!;
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public ReservationStatus Status { get; set; }
}

public enum ReservationStatus
{
    Planned,
    Confirmed,
    Cancelled
}
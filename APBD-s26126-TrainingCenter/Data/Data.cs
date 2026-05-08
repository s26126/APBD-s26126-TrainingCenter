using APBD_s26126_TrainingCenter.Models;

namespace APBD_s26126_TrainingCenter.Data;

public static class Data
{
    public static List<Room> Rooms { get; } =
    [
        new Room { Id = 1, Name = "Aula A", BuildingCode = "A", Floor = 0, Capacity = 100, HasProjector = true, IsActive = true },
        new Room { Id = 2, Name = "Sala B1", BuildingCode = "B", Floor = 1, Capacity = 30, HasProjector = true, IsActive = true },
        new Room { Id = 3, Name = "Sala B2", BuildingCode = "B", Floor = 1, Capacity = 20, HasProjector = false, IsActive = true },
        new Room { Id = 4, Name = "Sala C1", BuildingCode = "C", Floor = 2, Capacity = 15, HasProjector = false, IsActive = false },
        new Room { Id = 5, Name = "Sala C2", BuildingCode = "C", Floor = 2, Capacity = 25, HasProjector = true, IsActive = true },
    ];

    public static List<Reservation> Reservations { get; } =
    [
        new Reservation { Id = 1, RoomId = 1, OrganizerName = "Jan Kowalski", Topic = "Wykład inauguracyjny", Date = new DateOnly(2026, 5, 10), StartTime = new TimeOnly(9, 0), EndTime = new TimeOnly(11, 0), Status = ReservationStatus.Confirmed },
        new Reservation { Id = 2, RoomId = 2, OrganizerName = "Anna Nowak", Topic = "Warsztaty .NET", Date = new DateOnly(2026, 5, 10), StartTime = new TimeOnly(13, 0), EndTime = new TimeOnly(15, 0), Status = ReservationStatus.Planned },
        new Reservation { Id = 3, RoomId = 2, OrganizerName = "Piotr Wiśniewski", Topic = "Szkolenie SQL", Date = new DateOnly(2026, 5, 12), StartTime = new TimeOnly(10, 0), EndTime = new TimeOnly(12, 0), Status = ReservationStatus.Planned },
        new Reservation { Id = 4, RoomId = 5, OrganizerName = "Maria Zielińska", Topic = "Prezentacja projektu", Date = new DateOnly(2026, 5, 13), StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(16, 0), Status = ReservationStatus.Confirmed },
        new Reservation { Id = 5, RoomId = 3, OrganizerName = "Tomasz Maj", Topic = "Code review", Date = new DateOnly(2026, 5, 14), StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(9, 0), Status = ReservationStatus.Cancelled },
        new Reservation { Id = 6, RoomId = 1, OrganizerName = "Ewa Dąbrowska", Topic = "Egzamin praktyczny", Date = new DateOnly(2026, 5, 15), StartTime = new TimeOnly(12, 0), EndTime = new TimeOnly(14, 0), Status = ReservationStatus.Planned },
    ];
}

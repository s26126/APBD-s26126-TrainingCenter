using Microsoft.AspNetCore.Mvc;
using APBD_s26126_TrainingCenter.Data;
using APBD_s26126_TrainingCenter.Models;

namespace APBD_s26126_TrainingCenter.Controllers
{
    // api/reservations
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {

        // GET api/reservations
        // GET api/reservations?date=2026-05-10&status=confirmed&roomId=2
        [HttpGet]
        public IActionResult GetAll([FromQuery] DateOnly? date,[FromQuery] string? status, [FromQuery] int? roomId)
        {
            var reservations = Data.Data.Reservations.AsEnumerable();

            if (date.HasValue)
                reservations = reservations.Where(r => r.Date == date.Value);

            if (!string.IsNullOrEmpty(status) && Enum.TryParse<ReservationStatus>(status, true, out var parsedStatus))
                    reservations = reservations.Where(r => r.Status == parsedStatus);

            if (roomId.HasValue)
              reservations = reservations.Where(r => r.RoomId == roomId.Value);

            return Ok(reservations.ToList());
        }


        // GET api/reservations/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
          var reservation = Data.Data.Reservations.FirstOrDefault(r => r.Id == id);

            if (reservation == null)
                return NotFound();

            return Ok(reservation);
        }

        // POST api/reservations
        [HttpPost]
        public IActionResult Create([FromBody] Reservation reservation)
        {
          if (reservation.EndTime <= reservation.StartTime)
                return BadRequest("Godzina zakonczenia musi byc pozniejsza niz godzina rozpoczecia.");

            var room = Data.Data.Rooms.FirstOrDefault(r => r.Id == reservation.RoomId);

            if (room == null)
              return NotFound("Sala o podanym id nie istnieje.");

            if (!room.IsActive)
                return BadRequest("Sala jest nieaktywna i nie mozna jej zarezerwowac.");

            var collision = Data.Data.Reservations.Any(r =>
                r.RoomId == reservation.RoomId &&
                r.Date == reservation.Date &&
                r.StartTime < reservation.EndTime &&
                r.EndTime > reservation.StartTime);

            if (collision)
                return Conflict("W podanym terminie sala jest juz zajeta.");

            reservation.Id = Data.Data.Reservations.Count > 0 ? Data.Data.Reservations.Max(r => r.Id) + 1 : 1;
            Data.Data.Reservations.Add(reservation);

            return CreatedAtAction(nameof(GetById),new { id = reservation.Id }, reservation);
        }

    }
}
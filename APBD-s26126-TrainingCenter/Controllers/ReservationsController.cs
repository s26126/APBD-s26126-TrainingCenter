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

    }
}

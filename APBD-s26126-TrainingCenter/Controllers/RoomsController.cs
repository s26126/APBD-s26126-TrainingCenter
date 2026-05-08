using Microsoft.AspNetCore.Mvc;
using APBD_s26126_TrainingCenter.Data;

namespace APBD_s26126_TrainingCenter.Controllers
{
    // api/rooms
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {

        // GET api/rooms
        // GET api/rooms?minCapacity=20&hasProjector=true&activeOnly=true
        [HttpGet]
        public IActionResult GetAll([FromQuery] int? minCapacity, [FromQuery] bool? hasProjector, [FromQuery] bool? activeOnly)
        {
            var rooms = Data.Data.Rooms.AsEnumerable();

            if (minCapacity.HasValue)
                rooms = rooms.Where(r => r.Capacity >= minCapacity.Value);

            if (hasProjector.HasValue)
                rooms = rooms.Where(r => r.HasProjector == hasProjector.Value);

            if (activeOnly == true)
                rooms = rooms.Where(r => r.IsActive);

            return Ok(rooms.ToList());
        }

        // GET api/rooms/building/{buildingCode}
        [HttpGet("building/{buildingCode}")]
        public IActionResult GetByBuilding([FromRoute] string buildingCode)
        {
            var rooms = Data.Data.Rooms.Where(r => r.BuildingCode == buildingCode).ToList();

            return Ok(rooms);
        }

        // GET api/rooms/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var room = Data.Data.Rooms.FirstOrDefault(r => r.Id == id);

            if (room == null)
                return NotFound();

            return Ok(room);
        }

    }
}
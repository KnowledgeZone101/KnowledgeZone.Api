using KnowledgeZone.Domain.DTOs.Room;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeZone.Api.Controllers
{
    [Route("api/Room")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomDto>> GetRoom([FromQuery] RoomResourceParamentrs roomResourceParamentrs)
        {
            var room = _roomService.GetRoom(roomResourceParamentrs);

            return Ok(room);
        }

        [HttpGet("{id}", Name = "GetRoomById")]
        public ActionResult<RoomDto> Get(int id)
        {
            var room = _roomService.GetRoomById(id);

            return Ok(room);
        }

        [HttpPost]
        public ActionResult Post([FromQuery] RoomForCreateDto roomForCreateDto)
        {
            _roomService.CreateRoom(roomForCreateDto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RoomForUpdateDto roomForUpdateDto)
        {
            _roomService.UpdateRoom(roomForUpdateDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _roomService.DeleteRoom(id);

            return Ok();
        }
    }
}

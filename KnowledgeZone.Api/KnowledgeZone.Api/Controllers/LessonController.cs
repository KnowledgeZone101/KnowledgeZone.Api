using KnowledgeZone.Domain.DTOs.Lesson;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeZone.Api.Controllers
{
    [Route("api/lesson")]
    [ApiController]
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LessonDto>> GetLesson([FromQuery] LessonResourceParamentrs lessonResourceParamentrs)
        {
            var lesson = _lessonService.GetLesson(lessonResourceParamentrs);

            return Ok(lesson);
        }

        [HttpGet("{id}", Name = "GetLessonById")]
        public ActionResult<LessonDto> GetLesson(int id)
        {
            var lesson = _lessonService.GetLessonById(id);

            return Ok(lesson);
        }

        [HttpPost]
        public ActionResult Post([FromBody] LessonForCreateDto lessonForCreateDto)
        {
            _lessonService.CreateLesson(lessonForCreateDto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] LessonForUpdateDto lessonForUpdateDto)
        {
            _lessonService.UpdateLesson(lessonForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _lessonService.DeleteLesson(id);

            return NoContent();
        }
    }
}

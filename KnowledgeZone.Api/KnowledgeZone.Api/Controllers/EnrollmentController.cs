﻿using KnowledgeZone.Domain.DTOs.Enrollment;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeZone.Api.Controllers
{
    [Route("api/enrollment")]
    [ApiController]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnrollmentDto>> GetEnrollments([FromQuery] EnrollmentResourceParamentrs enrollmentResourceParamentrs)
        {
            var enrollments = _enrollmentService.GetEnrollment(enrollmentResourceParamentrs);

            return Ok(enrollments);
        }

        [HttpGet("{id}", Name = "GetEnrollmentById")]
        public ActionResult<EnrollmentDto> GetEnrollment(int id)
        {
            var enrollment = _enrollmentService.GetEnrollmentById(id);

            return Ok(enrollment);
        }

        [HttpPost]
        public ActionResult Post([FromBody] EnrollmentForCreateDto enrollmentForCreateDto)
        {
            _enrollmentService.CreateEnrollment(enrollmentForCreateDto);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EnrollmentForUpdateDto enrollmentForUpdateDto)
        {
            _enrollmentService.UpdateEnrollment(enrollmentForUpdateDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _enrollmentService.DeleteEnrollment(id);

            return Ok();
        }
    }
}
using AutoMapper;
using KnowledgeZone.Domain.DTOs.Enrollment;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using KnowledgeZone.Infrastructure;
using Microsoft.Extensions.Logging;

namespace KnowledgeZone.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IMapper _mapper;
        private readonly KnowledgeZoneDbContext _context;
        private readonly ILogger<EnrollmentService> _logger; 

        public EnrollmentService(IMapper mapper, KnowledgeZoneDbContext context, ILogger<EnrollmentService> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public PaginatedList<EnrollmentDto> GetEnrollment(EnrollmentResourceParamentrs enrollmentParameters)
        {
            var query = _context.Enrollments.AsQueryable();

            if (!string.IsNullOrEmpty(enrollmentParameters.SearchString))
            {
                query = query.Where(e => e.Name.Contains(enrollmentParameters.SearchString));
            }

            if(enrollmentParameters.OrderBy is not null)
            {
                switch (enrollmentParameters.OrderBy)
                {
                    case "name":
                        query = query.OrderBy(e => e.Name); break;
                    case "name_desc":
                        query = query.OrderByDescending(e => e.Name); break;
                }
            }

            var enrollments = query.ToPaginatedList(enrollmentParameters.PageSize, enrollmentParameters.PageNumber);
            var enrollmentDtos = _mapper.Map<PaginatedList<EnrollmentDto>>(enrollments);

            return new PaginatedList<EnrollmentDto>(enrollmentDtos, enrollments.TotalCount, enrollments.CurrentPage, enrollments.PageSize);
        }

        public EnrollmentDto? GetEnrollmentById(int id)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(e => e.Id == id);
            var enrollmentDto = _mapper.Map<EnrollmentDto>(enrollment);

            return enrollmentDto;
        }

        public EnrollmentDto CreateEnrollment(EnrollmentForCreateDto enrollmentToCreate)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentToCreate);

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            var enrollmentDto = _mapper.Map<EnrollmentDto>(enrollment);

            return enrollmentDto;
        }

        public void UpdateEnrollment(EnrollmentForUpdateDto enrollmentToUpdate)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentToUpdate);

            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
        }

        public void DeleteEnrollment(int id)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(e => e.Id == id);

            if(enrollment is not null)
            {
                _context.Enrollments.Remove(enrollment);
            }

            _context.SaveChanges();
        }
    }
}

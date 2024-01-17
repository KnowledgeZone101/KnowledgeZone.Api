using AutoMapper;
using KnowledgeZone.Domain.DTOs.Course;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using KnowledgeZone.Infrastructure;
using Microsoft.Extensions.Logging;

namespace KnowledgeZone.Service
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly KnowledgeZoneDbContext _context;
        private readonly ILogger<CourseService> _logger;

        public CourseService(IMapper mapper, KnowledgeZoneDbContext context, ILogger<CourseService> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }
        public PaginatedList<CourseDto> GetCourse(CourseResourceParamentrs courseResourceParameters)
        {
            var query = _context.Courses.AsQueryable();

            if (!string.IsNullOrEmpty(courseResourceParameters.SearchString))
            {
                query = query.Where(c => c.Name.Contains(courseResourceParameters.SearchString));
            }

            if(courseResourceParameters is not null)
            {
                switch (courseResourceParameters.OrderBy)
                {
                    case "name":
                        query = query.OrderBy(c => c.Name); break;
                    case "name_desc":
                        query = query.OrderByDescending(c => c.Name); break;
                    case "teacherId":
                        query = query.OrderBy(c => c.TeacherId); break;
                    case "teacherId_desc":
                        query = query.OrderByDescending(c => c.TeacherId); break;
                    case "departmentId":
                        query = query.OrderBy(c => c.Department); break;
                    case "department_desc":
                        query = query.OrderByDescending(c => c.Department); break;
                    case "enrollmentId":
                        query = query.OrderBy(c => c.Enrollment); break;
                    case "enrollment_desc":
                        query = query.OrderByDescending(c => c.Enrollment); break;
                    case "courseTypeId":
                        query = query.OrderBy(c => c.CourseTypeId); break;
                    case "courseTypeId_desc":
                        query = query.OrderByDescending(c => c.CourseTypeId); break;
                }
            }

            var courses = query.ToPaginatedList(courseResourceParameters.PageSize, courseResourceParameters.PageNumber);
            var coursesDto = _mapper.Map<PaginatedList<CourseDto>>(courses);

            return new PaginatedList<CourseDto>(coursesDto, courses.TotalCount, courses.CurrentPage, courses.PageSize);
        }

        public CourseDto? GetCourseById(int id)
        {
            var coruse = _context.Courses.FirstOrDefault(c => c.Id == id);

            var courseDto = _mapper.Map<CourseDto>(coruse);

            return courseDto;
        }

        public CourseDto CreateCourse(CourseForCreateDto courseToCreate)
        {
            var courseEntity = _mapper.Map<Course>(courseToCreate);

            _context.Courses.Add(courseEntity);
            _context.SaveChanges();

            var courseDto = _mapper.Map<CourseDto>(courseEntity);
            return courseDto;
        }

        public void UpdateCourse(CourseForUpdateDto courseToUpdate)
        {
            var courseEntity = _mapper.Map<Course>(courseToUpdate);

            _context.Courses.Update(courseEntity);  
            _context.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if(course != null)
            {
                _context.Courses.Remove(course);
            }
            _context.SaveChanges();
        }
    }
}

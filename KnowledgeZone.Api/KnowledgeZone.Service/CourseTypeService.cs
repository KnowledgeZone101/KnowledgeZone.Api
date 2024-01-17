using AutoMapper;
using KnowledgeZone.Domain.DTOs.Course;
using KnowledgeZone.Domain.DTOs.CourseType;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using KnowledgeZone.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Service
{
    public class CourseTypeService : ICourseTypeService
    {
        private readonly IMapper _mapper;
        private readonly KnowledgeZoneDbContext _context;
        private readonly ILogger<CourseTypeService> _logger;

        public CourseTypeService(IMapper mapper, KnowledgeZoneDbContext context, ILogger<CourseTypeService> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }
        public PaginatedList<CourseTypeDto> GetCourseType(CourseTypeResourceParamentrs courseTypeResourceParameters)
        {
            var query = _context.CourseTypes.AsQueryable();
            if (!string.IsNullOrEmpty(courseTypeResourceParameters.SearchString))
            {
                query = query.Where(c => c.Name.Contains(courseTypeResourceParameters.SearchString));
            }
            if (courseTypeResourceParameters.OrderBy is not null)
            {
                switch (courseTypeResourceParameters.OrderBy)
                {
                    case "name":
                        query = query.OrderBy(c => c.Name); break;
                    case "name_desc":
                        query = query.OrderByDescending(c => c.Name); break;
                }
            }

            var courseTypes = query.ToPaginatedList(courseTypeResourceParameters.PageSize, courseTypeResourceParameters.PageNumber);

            var courseTypesDto = _mapper.Map<PaginatedList<CourseTypeDto>>(courseTypes);

            return new PaginatedList<CourseTypeDto>(courseTypesDto, courseTypes.TotalCount, courseTypes.CurrentPage, courseTypes.PageSize);
        }

        public CourseTypeDto? GetCourseTypeById(int id)
        {
            var courseType = _context.CourseTypes.FirstOrDefault(c => c.Id == id);
            var courseTypeDto = _mapper.Map<CourseTypeDto>(courseType);

            return courseTypeDto;
        }
        public CourseTypeDto CreateCourseType(CourseTypeForCreateDto courseTypeToCreate)
        {
            var courseTypeEntity = _mapper.Map<CourseType>(courseTypeToCreate);

            _context.CourseTypes.Add(courseTypeEntity);
            _context.SaveChanges();

            var courseTypeDto = _mapper.Map<CourseTypeDto>(courseTypeEntity);

            return courseTypeDto;
        }
        public void UpdateCourseType(CourseTypeForUpdateDto courseTypeToUpdate)
        {
            var courseTypeEntity = _mapper.Map<CourseType>(courseTypeToUpdate);

            _context.CourseTypes.Update(courseTypeEntity);
            _context.SaveChanges();
        }

        public void DeleteCourseType(int id)
        {
            var courseType = _context.CourseTypes.FirstOrDefault(c => c.Id == id);

            if(courseType is not null)
            {
                _context.CourseTypes.Remove(courseType);
            }

            _context.SaveChanges();
        }
    }
}

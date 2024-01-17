using AutoMapper;
using KnowledgeZone.Domain.DTOs.Teacher;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using KnowledgeZone.Infrastructure;

namespace KnowledgeZone.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly IMapper _mapper;
        private readonly KnowledgeZoneDbContext _context;

        public PaginatedList<TeacherDto> GetTeacher(TeacherResourceParamentrs teacherParameters)
        {
            var query = _context.Teachers.AsQueryable();

            if (!string.IsNullOrEmpty(teacherParameters.SearchString))
            {
                query = query.Where(t => t.Name.Contains(teacherParameters.SearchString)
                || t.Email.Contains(teacherParameters.SearchString));
            }

            if(teacherParameters.OrderBy is not null)
            {
                switch (teacherParameters.OrderBy)
                {
                    case "name":
                        query = query.OrderBy(t => t.Name); break;
                    case "name_desc":
                        query = query.OrderByDescending(t => t.Name); break;
                    case "email":
                        query = query.OrderBy(t => t.Email); break;
                    case "email_desc":
                        query = query.OrderByDescending(t => t.Email); break;
                        case "qualification":
                        query = query.OrderBy(t => t.Qualification); break;
                    case "qualification_desc":
                        query = query.OrderByDescending(t => t.Qualification); break;
                }
            }

            var teachers = query.ToPaginatedList(teacherParameters.PageSize, teacherParameters.PageNumber);
            var teacherDtos = _mapper.Map<PaginatedList<TeacherDto>>(teachers);

            return new PaginatedList<TeacherDto>(teacherDtos, teachers.TotalCount, teachers.CurrentPage, teachers.PageSize);
        }

        public TeacherDto? GetTeacherById(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            return teacherDto;
        }

        public TeacherDto CreateTeacher(TeacherForCreateDto teacherToCreate)
        {
            var teacher = _mapper.Map<Teacher>(teacherToCreate);

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            return teacherDto;
        }

        public void UpdateTeacher(TeacherForUpdateDto teacherToUpdate)
        {
            var teacher = _mapper.Map<Teacher>(teacherToUpdate);

            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }

        public void DeleteTeacher(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);

            if(teacher is not null)
            {
                _context.Teachers.Remove(teacher);
            }

            _context.SaveChanges();
        }
    }
}

using AutoMapper;
using KnowledgeZone.Domain.DTOs.Student;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using KnowledgeZone.Infrastructure;
using Microsoft.IdentityModel.Tokens;

namespace KnowledgeZone.Service
{
    public class StudentService : IStudentService
    {
        private readonly KnowledgeZoneDbContext _context;
        private readonly IMapper _mapper;

        public PaginatedList<StudentDto> GetStudent(StudentResourceParamentrs studentParameters)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(studentParameters.SearchString))
            {
                query = query.Where(s => s.Name.Contains(studentParameters.SearchString)
                ||s.Email.Contains(studentParameters.SearchString));
            }

            if(studentParameters.OrderBy is not null)
            {
                switch (studentParameters.OrderBy)
                {
                    case "name":
                        query = query.OrderBy(s => s.Name); break;
                    case "name_desc":
                        query = query.OrderByDescending(s => s.Name); break;
                    case "email":
                        query = query.OrderBy(s => s.Email); break;
                    case "email_desc":
                        query = query.OrderByDescending(s => s.Email); break;
                        case "enrollmentId":
                        query = query.OrderBy(s => s.Enrollment); break;
                    case "enrollment_desc":
                        query = query.OrderByDescending(s => s.Enrollment); break;
                }
            }

            var students = query.ToPaginatedList(studentParameters.PageSize, studentParameters.PageNumber);
            var studentDtos = _mapper.Map<PaginatedList<StudentDto>>(students);

            return new PaginatedList<StudentDto>(studentDtos, students.TotalCount, students.CurrentPage, students.PageSize);
        }

        public StudentDto? GetStudentById(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            var studentDto = _mapper.Map<StudentDto>(student);

            return studentDto;
        }
        public StudentDto CreateStudent(StudentForCreateDto studentToCreate)
        {
            var student = _mapper.Map<Student>(studentToCreate);

            _context.Students.Add(student);
            _context.SaveChanges();

            var studentDto = _mapper.Map<StudentDto>(student);

            return studentDto;
        }
        public void UpdateStudent(StudentForUpdateDto studentToUpdate)
        {
            var student = _mapper.Map<Student>(studentToUpdate);

            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student is not null)
            {
                _context.Students.Remove(student);
            }

            _context.SaveChanges();
        }
    }
}

using AutoMapper;
using KnowledgeZone.Domain.DTOs.Lesson;
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
    public class LessonService : ILessonService
    {
        private readonly IMapper _mapper;
        private readonly KnowledgeZoneDbContext _context;
        private readonly ILogger<LessonService> _logger;

        public PaginatedList<LessonDto> GetLesson(LessonResourceParamentrs lessonParameters)
        {
            var query = _context.Lessons.AsQueryable();

            if (!string.IsNullOrEmpty(lessonParameters.SearchString))
            {

            }

            if (lessonParameters.OrderBy is not null)
            {
                switch (lessonParameters.OrderBy)
                {
                    case "startTime":
                        query = query.OrderBy(l => l.StartTime); break;
                    case "startTime_desc":
                        query = query.OrderByDescending(l => l.StartTime); break;
                    case "finishTime":
                        query = query.OrderBy(l => l.FinishTime); break;
                    case "finishTime_desc":
                        query = query.OrderByDescending(l => l.FinishTime); break;
                    case "roomId":
                        query = query.OrderBy(l => l.RoomId); break;
                    case "roomId_desc":
                        query = query.OrderByDescending(l => l.RoomId); break;
                    case "courseId":
                        query = query.OrderBy(l => l.CourseId); break;
                    case "courseId_desc":
                        query = query.OrderByDescending(l => l.CourseId); break;
                    //case "attendanceId":
                    //    query = query.OrderBy(l => l.AttendanceId); break;
                    //case "attendanceId_desc":
                    //    query = query.OrderByDescending(l => l.AttendanceId); break;
                }
            }

            var lessons = query.ToPaginatedList(lessonParameters.PageSize, lessonParameters.PageNumber);
            var lessonDto = _mapper.Map<PaginatedList<LessonDto>>(lessons);

            return new PaginatedList<LessonDto>(lessonDto, lessons.TotalCount, lessons.CurrentPage, lessons.PageSize);
        }

        public LessonDto? GetLessonById(int id)
        {
            var lesson = _context.Lessons.FirstOrDefault(e =>e.Id == id);
            var lessonDto = _mapper.Map<LessonDto>(lesson);

            return lessonDto;
        }
        public LessonDto CreateLesson(LessonForCreateDto lessonToCreate)
        {
            var lesson = _mapper.Map<Lesson>(lessonToCreate);

            _context.Lessons.Add(lesson);
            _context.SaveChanges();

            return _mapper.Map<LessonDto>(lesson);
        }
        public void UpdateLesson(LessonForUpdateDto lessonToUpdate)
        {
            var lesson = _mapper.Map<Lesson>(lessonToUpdate);

            _context.Lessons.Update(lesson);
            _context.SaveChanges();
        }

        public void DeleteLesson(int id)
        {
            var lesson = _context.Lessons.FirstOrDefault(e => e.Id == id);
            if(lesson != null)
            {
                _context.Lessons.Remove(lesson);
            }
            _context.SaveChanges();
        }
    }
}

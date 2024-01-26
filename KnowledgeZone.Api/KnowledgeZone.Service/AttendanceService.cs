using AutoMapper;
using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using KnowledgeZone.Infrastructure;
using KnowledgeZone.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace KnowledgeZone.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IMapper _mapper;
        private readonly KnowledgeZoneDbContext _context;
        private readonly ILogger<AttendanceService> _logger;

        public AttendanceService(IMapper mapper, KnowledgeZoneDbContext context, ILogger<AttendanceService> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }
        public PaginatedList<AttendanceDto> GetAttendance(AttendanceResourceParameters attendanceResourceParameters)
        {
            var query = _context.Attendances.AsQueryable();

            if (!string.IsNullOrEmpty(attendanceResourceParameters.SearchString))
            {

            }

            if (!string.IsNullOrEmpty(attendanceResourceParameters.OrderBy))
            {
                switch (attendanceResourceParameters.OrderBy)
                {
                        case "studentId":
                        query = query.OrderBy(a => a.StudentId); break;
                        case "studentId_desc":
                        query = query.OrderByDescending(a => a.StudentId); break;
                }
            }

            var attendances = query.ToPaginatedList(attendanceResourceParameters.PageSize, attendanceResourceParameters.PageNumber);
            var attendancesDto = _mapper.Map<List<AttendanceDto>>(attendances);

            return new PaginatedList<AttendanceDto>(attendancesDto, attendances.TotalCount,attendances.CurrentPage,attendances.PageSize);
        }

        public AttendanceDto? GetAttendanceById(int id)
        {
            var attendance = _context.Attendances.FirstOrDefault(a => a.Id == id);

            var attendamceDto = _mapper.Map<AttendanceDto>(attendance);

            return attendamceDto;
        }
        public AttendanceDto CreateAttendance(AttendanceForCreateDto attendanceToCreate)
        {
            var attendanceEntity = _mapper.Map<Attendance>(attendanceToCreate);

            _context.Attendances.Add(attendanceEntity);
            _context.SaveChanges(); 

            var attendancesDto = _mapper.Map<AttendanceDto>(attendanceEntity);

            return attendancesDto;
        }

        public void UpdateAttendance(AttendanceForUpdateDto attendanceToUpdate)
        {
            var attendanceEntity = _mapper.Map<Attendance>(attendanceToUpdate); 

            _context.Attendances.Update(attendanceEntity);
            _context.SaveChanges();
        }


        public void DeleteAttendance(int id)
        {
            var attendance = _context.Attendances.FirstOrDefault(a => a.Id == id);

            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
            }
            _context.SaveChanges();
        }       
    }
}

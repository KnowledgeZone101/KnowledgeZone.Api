using KnowledgeZone.Domain.Common;

namespace KnowledgeZone.Domain.Entities
{
    public class Lesson : EntityBase
    {
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int CourseId { get; set; }
        public Course Courses { get; set; }
        public int AttendanceId { get; set; }
        public Attendance Attendance { get; set; }
    }
}

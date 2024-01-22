using KnowledgeZone.Domain.Common;

namespace KnowledgeZone.Domain.Entities
{
    public class Lesson : EntityBase
    {
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public virtual ICollection<Attendance>? Attendances { get; set; }

    }
}

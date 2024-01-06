using KnowledgeZone.Domain.Common;

namespace KnowledgeZone.Domain.Entities
{
    public class Attendance : EntityBase
    {
        public int StudentId { get; set; }
        public AttendanceType AttendanceType { get; set; }
        public Mark? Mark { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        //public virtual ICollection<Lesson> Lessons { get; set; }
    }

    public enum Mark
    {
        A,  // Excellent
        B,  // Good
        C,  // Satisfactory
        D,  // Passing but below average
        F   // Fail
    }
    public enum AttendanceType
    {
        Absent,
        Late,
        Present
    }

}


using KnowledgeZone.Domain.Common;

namespace KnowledgeZone.Domain.Entities
{
    public class Course : EntityBase
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
        public int CourseTypeId { get; set; }
        public CourseType CourseType { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}

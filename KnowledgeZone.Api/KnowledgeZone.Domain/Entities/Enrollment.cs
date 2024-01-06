using KnowledgeZone.Domain.Common;

namespace KnowledgeZone.Domain.Entities
{
    public class Enrollment : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public Enrollment(List<Student> students)
        {
            Students = students;
        }
    }
}

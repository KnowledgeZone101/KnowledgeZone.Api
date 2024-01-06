using KnowledgeZone.Domain.Common;

namespace KnowledgeZone.Domain.Entities
{
    public class Teacher : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int QualificationId { get; set; }
        public Qualification Qualification { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}

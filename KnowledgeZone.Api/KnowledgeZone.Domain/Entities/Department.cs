using KnowledgeZone.Domain.Common;

namespace KnowledgeZone.Domain.Entities
{
    public class Department : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}

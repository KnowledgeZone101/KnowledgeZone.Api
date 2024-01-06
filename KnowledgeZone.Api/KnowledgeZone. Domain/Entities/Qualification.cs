using KnowledgeZone.Domain.Common;

namespace KnowledgeZone.Domain.Entities
{
    public class Qualification : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}

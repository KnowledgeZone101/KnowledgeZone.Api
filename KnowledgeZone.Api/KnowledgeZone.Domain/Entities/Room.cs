using KnowledgeZone.Domain.Common;

namespace KnowledgeZone.Domain.Entities
{
    public class Room : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}

using KnowledgeZone.Domain.Common;

namespace KnowledgeZone.Domain.Entities
{
    public class Student : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}

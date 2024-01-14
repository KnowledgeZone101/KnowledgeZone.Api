using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Infrastructure.Persistence.Repositories
{
    public class LessonRepository : RepositoryBase<Lesson>, ILessonRepository   
    {
        public LessonRepository(KnowledgeZoneDbContext context) : base(context) { }
    }
}

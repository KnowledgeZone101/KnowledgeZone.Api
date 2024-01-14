using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Infrastructure.Persistence.Repositories
{
    public class CourseTypeRepository : RepositoryBase<CourseType>, ICourseTypeRepository
    {
        public CourseTypeRepository(KnowledgeZoneDbContext context) : base(context)
        {

        }
    }
}

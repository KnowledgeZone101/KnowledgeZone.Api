using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Infrastructure.Persistence.Repositories
{
    public class QualificationRepository : RepositoryBase<Qualification>, IQualificationRepository
    {
        public QualificationRepository(KnowledgeZoneDbContext context) : base(context)
        { }
    }
}

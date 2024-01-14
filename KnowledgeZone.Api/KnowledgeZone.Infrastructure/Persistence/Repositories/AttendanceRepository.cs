using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Infrastructure.Persistence.Repositories
{
    public class AttendanceRepository : RepositoryBase<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(KnowledgeZoneDbContext context) : base(context)
        {
        }
    }
}

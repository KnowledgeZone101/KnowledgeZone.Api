using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.Interfaces.Repository
{
    public class ICommonRepository
    {
        public IAttendanceRepository Attendence { get;}
        public ICourseRepository Course { get;}
        public ICourseTypeRepository CourseType { get; }
        public IDepartmentRepository Department { get; }    
        public IEnrollmentRepository Enrollment { get; }
        public ILessonRepository Lesson { get; }
        public IQualificationRepository Qualification { get; }  
        public IRoomRepository Room { get; }
        public IStudentRepository Student { get; }  
        public ITeacherRepository Teacher { get; }
    }
}

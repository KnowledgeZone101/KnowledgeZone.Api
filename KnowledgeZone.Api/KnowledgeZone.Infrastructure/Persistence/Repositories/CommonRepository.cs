using KnowledgeZone.Domain.Interfaces.Repository;

namespace KnowledgeZone.Infrastructure.Persistence.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly KnowledgeZoneDbContext _context;

        #region Attendance
        private IAttendanceRepository _attendance;
        public IAttendanceRepository Attendance
        {
            get
            {
                _attendance ??= new AttendanceRepository(_context);

                return _attendance;
            }
        }
        #endregion

        #region Course
        private ICourseRepository _course;
        public ICourseRepository Course
        {
            get
            {
                _course ??= new CourseRepository(_context);
                return _course;
            }
        }
        #endregion  

        #region CourseType
        private ICourseTypeRepository _courseType;
        public ICourseTypeRepository CourseType
        {
            get
            {
                _courseType ??= new CourseTypeRepository(_context);
                return _courseType;
            }
        }
        #endregion

        #region Department
        private IDepartmentRepository _department;
        public IDepartmentRepository Department
        {
            get
            {
                _department ??= new DepartmentRepository(_context);
                return _department;
            }
        }
        #endregion  

        #region Enrollment
        private IEnrollmentRepository _enrollment;
        public IEnrollmentRepository Enrollment
        {
            get
            {
                _enrollment ??= new EnrollmentRepository(_context);
                return _enrollment;
            }
        }
        #endregion  

        #region Lesson
        private ILessonRepository _lesson;
        public ILessonRepository Lesson
        {
            get
            {
                _lesson ??= new LessonRepository(_context);
                return _lesson;
            }
        }
        #endregion

        #region Student
        private IStudentRepository _student;
        public IStudentRepository Student
        {
            get
            {
                _student ??= new StudentRepository(_context);
                return _student;
            }
        }
        #endregion  

        #region Teacher
        private ITeacherRepository _teacher;
        public ITeacherRepository Teacher
        {
            get
            {
                _teacher ??= new TeacherRepository(_context);
                return _teacher;
            }
        }
        #endregion

        #region Qualification
        private IQualificationRepository _qualification;
        public IQualificationRepository Qualification
        {
            get
            {
                _qualification ??= new QualificationRepository(_context);
                return _qualification;
            }
        }
        #endregion

        #region Room
        private IRoomRepository _room;
        public IRoomRepository Room
        {
            get
            {
                _room ??= new RoomRepository(_context);
                return _room;
            }
        }
        #endregion  


        public CommonRepository(KnowledgeZoneDbContext context)
        {
            _context = context;

            _attendance = new AttendanceRepository(context);
            _course = new CourseRepository(context);
            _courseType = new CourseTypeRepository(context);
            _department = new DepartmentRepository(context);
            _enrollment = new EnrollmentRepository(context);
            _lesson = new LessonRepository(context);
            _student = new StudentRepository(context);
            _teacher = new TeacherRepository(context);
            _qualification = new QualificationRepository(context);
            _room = new RoomRepository(context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}

using Bogus;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Infrastructure;
using KnowledgeZone.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;


namespace KnowledgeZone.Api.Extensions
{
    public static class DatabaseSeeder
    {
        private static Faker _faker = new Faker();


        public static void SeedDatabase(this IServiceCollection _, IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<KnowledgeZoneDbContext>>();
            using var context = new KnowledgeZoneDbContext(options);

            createEnrollments(context);
            createStudents(context);
            createQualification(context);
            createTeachers(context);
            createRooms(context);
            createDepartments(context);
            createCourseTypes(context);
            createCourse(context);
            createLessons(context);
            createAttendance(context);

            context.SaveChanges();
        }
        private static void createStudents(KnowledgeZoneDbContext context)
        {
            if (context.Students.Any()) return;

            var students = new List<Student>();
            var enrollments = context.Enrollments.ToList();

            foreach (var enrollment in enrollments)
            {
                int randomNumber = _faker.Random.Int(20, 24);

                for (int i = 0; i < randomNumber; i++)
                {
                    students.Add(new Student
                    {
                        Name = _faker.Name.FullName(),
                        Email = _faker.Internet.Email(),
                        EnrollmentId = enrollment.Id,
                    });
                }

            }

            context.Students.AddRange(students);
            context.SaveChanges();
        }

        private static void createQualification(KnowledgeZoneDbContext context)
        {
            if (context.Qualifications.Any()) return;

            var qualifications = new List<Qualification>
            {

                new Qualification { Name = "Management" },
                new Qualification { Name = "Finance" },
                new Qualification { Name = "Marketing" },
                new Qualification { Name = "Human Resources" },
                new Qualification { Name = "IT" },
                new Qualification { Name = "Engineering" },
                new Qualification { Name = "Business" },
                new Qualification { Name = "Machine Learning" },
            };

            context.Qualifications.AddRange(qualifications);
            context.SaveChanges();
        }
        private static void createTeachers(KnowledgeZoneDbContext context)
        {
            if (context.Teachers.Any()) return;

            var qualifications = context.Qualifications.ToList();

            var teachers = new List<Teacher>();

            foreach (var qualification in qualifications)
            {
                int random = _faker.Random.Int(1, 3);

                for (int i = 0; i < random; i++)
                {
                    teachers.Add(new Teacher
                    {
                        Name = _faker.Name.FullName(),
                        Email = _faker.Internet.Email(),
                        QualificationId = qualification.Id
                    });
                }
            }

            context.Teachers.AddRange(teachers);
            context.SaveChanges();
        }
        private static void createEnrollments(KnowledgeZoneDbContext context)
        {
            if (context.Enrollments.Any()) return;

            var students = context.Students.ToList();

            var enrollments = new List<Enrollment>();

            for (int i = 0; i < 21; i++)
            {
                enrollments.Add(new Enrollment
                {
                    Name = "G" + i
                });
            }

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
        private static void createDepartments(KnowledgeZoneDbContext context)
        {
            if (context.Departments.Any()) return;

            var departments = new List<Department>();

            for (int i = 0; i < 5; i++)
            {
                departments.Add(new Department
                {
                    Name = _faker.Company.CompanyName(),
                });
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();
        }
        private static void createCourseTypes(KnowledgeZoneDbContext context)
        {
            if (context.CourseTypes.Any()) return;

            var courseTypes = new List<CourseType>
            {
                new CourseType { Name = "Business Communication" },
                new CourseType { Name = "Business Management" },
                new CourseType { Name = "Algebra" },
                new CourseType { Name = "Calculus" },
                new CourseType { Name = "Problem Solving in Business" },
                new CourseType { Name = "Data Science" },
                new CourseType { Name = "Machine Learning" },
                new CourseType { Name = "Cyber Security" },
                new CourseType { Name = "Artificial Intelligence" },
                new CourseType { Name = "Data Analytics" },
                new CourseType { Name = "Computer Science" },
                new CourseType { Name = "Software Engineering" },
                new CourseType { Name = "Ethics" },
                new CourseType { Name = "Business Law" },
            };

            context.CourseTypes.AddRange(courseTypes);
            context.SaveChanges();
        }

        private static void createRooms(KnowledgeZoneDbContext context)
        {
            if (context.Rooms.Any()) return;

            var rooms = new List<Room>();

            for (int i = 0; i < 50; i++)
            {
                rooms.Add(new Room
                {
                    Name = _faker.Company.CompanyName(),
                });
            }

            context.Rooms.AddRange(rooms);
            context.SaveChanges();
        }

        private static void createCourse(KnowledgeZoneDbContext context)
        {
            if (context.Courses.Any()) return;

            Random random = new Random();

            var courses = new List<Course>();

            var enrollments = context.Enrollments.ToList();
            var courseTypes = context.CourseTypes.ToList();
            var departments = context.Departments.ToList();
            var teacher = context.Teachers.ToList();

            for (int i = 0; i < enrollments.Count; i++)
            {
                int numberOfCourses = random.Next(5, 11);
                List<CourseType> randomCourseTypes = courseTypes.OrderBy(x => random.Next()).Take(numberOfCourses).ToList();
                for (int j = 0; j < randomCourseTypes.Count; j++)
                {
                    courses.Add(new Course
                    {
                        Name = randomCourseTypes[j].Name,
                        EnrollmentId = enrollments[i].Id,
                        CourseTypeId = randomCourseTypes[j].Id,
                        DepartmentId = departments[random.Next(departments.Count)].Id,
                        TeacherId = teacher[random.Next(teacher.Count)].Id,
                    });
                }
            }

            context.Courses.AddRange(courses);
            context.SaveChanges();
        }

        private static void createLessons(KnowledgeZoneDbContext context)
        {
            if (context.Lessons.Any()) return;

            Random random = new Random();
            DateTime currentDate = DateTime.Now;

            var lessons = new List<Lesson>();

            var courses = context.Courses.ToList();
            var room = context.Rooms.ToList();
            foreach (var course in courses)
            {
                for (int i = 0; i < 64; i++)
                {
                    //lessons.Add(new Lesson
                    //{
                    //    CourseId = course.Id,
                    //    RoomId = room[random.Next(room.Count)].Id,
                    //    StartTime = currentDate.AddMinutes(random.Next(480, 1020)),
                    //    FinishTime = lessons[i].StartTime.AddMinutes(random.Next(60, 180)),
                    //});

                    var newLesson = new Lesson
                    {
                        CourseId = course.Id,
                        RoomId = room[random.Next(room.Count)].Id,
                        StartTime = currentDate.AddMinutes(random.Next(480, 1020)),
                    };

                    if (lessons.Any())
                    {
                        var lastLesson = lessons.Last();
                        newLesson.FinishTime = lastLesson.StartTime.AddMinutes(random.Next(60, 180));
                    }

                    lessons.Add(newLesson);
                }
            }

            context.Lessons.AddRange(lessons);
            context.SaveChanges();
        }

        private static void createAttendance(KnowledgeZoneDbContext context)
        {
            if (context.Attendances.Any()) return;

            var attendances = new List<Attendance>();

            var lessons = context.Lessons.ToList();
            
            foreach (var lesson in lessons)
            {
                if (lesson.Course == null || lesson.Course.Enrollment == null || lesson.Course.Enrollment.Students == null)
                {
                    continue;
                }

                var studentsInCourse = lesson.Course.Enrollment.Students;

                foreach (var student in studentsInCourse)
                {
                    attendances.Add(new Attendance
                    {
                        LessonId = lesson.Id,
                        StudentId = student.Id,
                        AttendanceType = (AttendanceType)Random.Shared.Next(0, Enum.GetValues(typeof(AttendanceType)).Length),
                        Mark = (Mark)Random.Shared.Next(0, Enum.GetValues(typeof(Mark)).Length),
                    });
                }
            }
            context.Attendances.AddRange(attendances);
            context.SaveChanges();  
        }
    }
}

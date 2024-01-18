using KnowledgeZone.Domain.Interfaces.Repository;
using KnowledgeZone.Infrastructure;
using KnowledgeZone.Infrastructure.Persistence.Interceptors;
using KnowledgeZone.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace KnowledgeZone.Api.Extensions
{
    public static class ConfigureServicesExtensions
    {

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            var builder = WebApplication.CreateBuilder();

            services.AddDbContext<KnowledgeZoneDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("KnowledgeZone")));

            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<ICourseTypeRepository, CourseTypeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<LongQueryIntercepters>();

            return services;
        }

        public static IServiceCollection ConfigureLogger(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.File("logs/error_.txt", Serilog.Events.LogEventLevel.Error, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            return services;
        }

        public static IServiceCollection ConfigureDatabaseContext(this IServiceCollection services)
        {
            var builder = WebApplication.CreateBuilder();

            services.AddDbContext<KnowledgeZoneDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("KnowledgeZone")));

            return services;
        }
    }
}

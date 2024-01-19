using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Interfaces.Repository;
using KnowledgeZone.Infrastructure;
using KnowledgeZone.Infrastructure.Persistence.Interceptors;
using KnowledgeZone.Infrastructure.Persistence.Repositories;
using KnowledgeZone.Service;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace KnowledgeZone.Api.Extensions
{
    public static class ConfigureServicesExtensions
    {

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {

            services.AddScoped<ICommonRepository, CommonRepository>();

            return services;
        }
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseTypeService, CourseTypeService>();
            services.AddScoped<IDepartmentService, DeapartmentService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IQualificationService, QualificationService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();

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

            services.AddDbContext<KnowledgeZoneDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("KnowledgeZone")));

            return services;
        }
    }
}

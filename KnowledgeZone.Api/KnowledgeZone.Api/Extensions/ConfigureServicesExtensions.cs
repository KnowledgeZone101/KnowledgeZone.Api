using KnowledgeZone.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeZone.Api.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureDatabaseContext(this IServiceCollection services)
        {
            var builder = WebApplication.CreateBuilder();

            services.AddDbContext<KnowledgeZoneDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("KnowledgeZone")));

            return services;
        }
    }
}

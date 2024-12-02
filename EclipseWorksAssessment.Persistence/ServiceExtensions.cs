using EclipseWorksAssessment.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EclipseWorksAssessment.Persistence
{
    public static class ServiceExtensions
    {
        //public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddDbContext<AppDbContext>(options =>
        //        options.UseSqlServer(configuration.GetConnectionString("EclipseWorksCs")));

        //    services.AddScoped<IProjectRepository, ProjectRepository>();
        //}

        public static void MigrationInitializer(this IApplicationBuilder serviceProvider)
        {
            using (var scope = serviceProvider.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }
        }
    }
}

using EclipseWorksAssessment.Persistence.Context;
using EclipseWorksAssessment.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EclipseWorksAssessment.Persistence
{
    //public static class ServiceExtensions
    //{
    //    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    //    {
    //        services.AddDbContext<AppDbContext>(options =>
    //            options.UseSqlServer(configuration.GetConnectionString("EclipseWorksCs")));

    //        services.AddScoped<IProjectService, ProjectService>();
    //        services.AddScoped<ITaskRepository, TaskRepository>();
    //        services.AddScoped<IUserCommentRepository, UserCommentRepository>();
    //    }

    //    public static void MigrationInitializer(this IApplicationBuilder serviceProvider)
    //    {
    //        using (var scope = serviceProvider.ApplicationServices.CreateScope())
    //        {
    //            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    //            context.Database.Migrate();
    //        }
    //    }

    //}
}

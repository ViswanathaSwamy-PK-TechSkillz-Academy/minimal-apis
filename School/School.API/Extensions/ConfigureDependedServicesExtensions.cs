using Microsoft.EntityFrameworkCore;
using School.API.Configurations;
using School.ApplicationCore.Interfaces;
using School.Business;
using School.Persistence;
using School.Repositories;

namespace School.API.Extensions;

public static class ConfigureDependedServicesExtensions
{

    public static IServiceCollection ConfigureDependedServices(this IServiceCollection services, string connectionString)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen();

        _ = services.AddDbContext<SchoolDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

        _ = services.AddScoped<ICoursesBusiness, CoursesBusiness>();

        _ = services.AddScoped<ICoursesRepository, CoursesRepository>();

        _ = services.AddAutoMapper(typeof(AutoMapperConfig));

        _ = services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

        return services;
    }

}

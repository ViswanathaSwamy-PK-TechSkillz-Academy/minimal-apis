using School.API.Endpoints;
using School.API.Persistence;

namespace School.API.Extensions;

public static class HttpRequestPipelineExtensions
{

    public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI();

            app.UseCors("AllowAll");

            // TODO: To be removed once we have .sqlproj
            using var scope = app.Services.CreateScope();
            using var context = scope.ServiceProvider.GetService<SchoolDbContext>();
            _ = (context?.Database.EnsureCreated());
        }

        // Endpoints
        app.MapHelloWorldEndpoints();
        app.MapCourseEndpoints();

        return app;
    }

}

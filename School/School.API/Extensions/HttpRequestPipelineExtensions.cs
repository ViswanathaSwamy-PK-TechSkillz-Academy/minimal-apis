using School.API.Endpoints;

namespace School.API.Extensions;

public static class HttpRequestPipelineExtensions
{

    public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapHelloWorldEndpoints();

        //app.MapCourseEndpoints();

        app.UseCors("AllowAll");

        return app;
    }
}

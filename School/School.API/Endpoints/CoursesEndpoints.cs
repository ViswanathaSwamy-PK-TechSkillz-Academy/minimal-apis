using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Dtos;
using School.Data.Entities;
using School.Persistence;
using static School.ApplicationCore.Common.Constants;

namespace School.API.Endpoints;

public static class CoursesEndpoints
{

    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        _ = routes.MapGet(CoursesRoutes.Root, async ([FromServices] SchoolDbContext schoolAppDbContext, [FromServices] IMapper mapper) =>
        {
            var coursesDto = mapper.Map<IReadOnlyCollection<CourseDto>>(await schoolAppDbContext.Courses.ToListAsync());
            return Results.Ok(coursesDto);

        }).AllowAnonymous()
          .WithTags(nameof(Course))
          .WithName("GetAllCourses")
          .Produces<IReadOnlyCollection<Course>>(StatusCodes.Status200OK)
          .WithOpenApi();

    }

}

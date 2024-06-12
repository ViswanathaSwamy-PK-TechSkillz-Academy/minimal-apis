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

        _ = routes.MapGet(CoursesRoutes.ActionById, async ([FromServices] SchoolDbContext schoolAppDbContext, [FromServices] IMapper mapper, [FromRoute] Guid Id) =>
        {
            return await schoolAppDbContext.Courses.FindAsync(Id) is Course course
                ? Results.Ok(mapper.Map<CourseDto>(course))
                : Results.NotFound();

        }).AllowAnonymous()
          .WithTags(nameof(Course))
          .WithName("GetCourseById")
          .Produces<CourseDto>(StatusCodes.Status200OK)
          .Produces(StatusCodes.Status404NotFound)
          .WithOpenApi();

        _ = routes.MapPost(CoursesRoutes.Root, async ([FromServices] SchoolDbContext schoolAppDbContext, [FromBody] Course course) =>
        {
            await schoolAppDbContext.Courses.AddAsync(course);
            await schoolAppDbContext.SaveChangesAsync();

            return Results.Created($"{CoursesRoutes.Root}/{course.Id}", course);
        }).WithTags(nameof(Course))
          .WithName("AddCourse")
          .Produces<Course>(StatusCodes.Status201Created)
          .WithOpenApi();

        _ = routes.MapPut(CoursesRoutes.Root, async ([FromServices] SchoolDbContext schoolAppDbContext, [FromBody] Course course, Guid Id) =>
        {
            var courseExists = await schoolAppDbContext.Courses.AnyAsync(r => r.Id == Id);
            if (!courseExists)
            {
                return Results.NotFound();
            }

            schoolAppDbContext.Update(course);
            await schoolAppDbContext.SaveChangesAsync();

            return Results.NoContent();
        }).WithTags(nameof(Course))
          .WithName("UpdateCourseById")
          .Produces(StatusCodes.Status204NoContent)
          .Produces(StatusCodes.Status404NotFound)
          .WithOpenApi();

        _ = routes.MapDelete(CoursesRoutes.ActionById, async ([FromServices] SchoolDbContext schoolAppDbContext, Guid Id) =>
        {
            var course = await schoolAppDbContext.Courses.FindAsync(Id);
            if (course is null)
            {
                return Results.NotFound();
            }

            schoolAppDbContext.Remove(course);
            await schoolAppDbContext.SaveChangesAsync();

            return Results.NoContent();
        }).WithTags(nameof(Course))
          .WithName("DeleteCourseById")
          .Produces<Course>(StatusCodes.Status204NoContent)
          .Produces(StatusCodes.Status404NotFound)
          .WithOpenApi();
    }

}

using Microsoft.Extensions.Logging;
using School.ApplicationCore.Interfaces;
using School.Data.Dtos;

namespace School.Business;

public class CoursesBusiness(ICoursesRepository coursesRepository, ILogger<CoursesBusiness> logger) : ICoursesBusiness
{
    private readonly ICoursesRepository _coursesRepository = coursesRepository ?? throw new ArgumentNullException(nameof(coursesRepository));
    private readonly ILogger<CoursesBusiness> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<ApiResponseDto<IReadOnlyCollection<CourseDto>>> GetAllCourses()
    {
        _logger.LogInformation($"Starting CoursesBusiness::GetAllCourses()");

        var courses = await _coursesRepository.GetAllCourses();

        return ApiResponseDto<IReadOnlyCollection<CourseDto>>.Create(courses);
    }

}

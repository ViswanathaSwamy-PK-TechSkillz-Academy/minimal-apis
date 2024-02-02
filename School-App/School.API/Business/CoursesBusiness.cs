using School.API.ApplicationCore.Interfaces;
using School.API.Data.DTOs;

namespace School.API.Business;

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

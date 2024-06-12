using School.Data.Dtos;

namespace School.ApplicationCore.Interfaces;

public interface ICoursesBusiness
{
    Task<ApiResponseDto<IReadOnlyCollection<CourseDto>>> GetAllCourses();
}

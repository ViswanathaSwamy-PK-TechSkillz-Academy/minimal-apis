using School.API.Data.DTOs;

namespace School.API.ApplicationCore.Interfaces;

public interface ICoursesRepository
{
    Task<IReadOnlyCollection<CourseDto>> GetAllCourses();
}


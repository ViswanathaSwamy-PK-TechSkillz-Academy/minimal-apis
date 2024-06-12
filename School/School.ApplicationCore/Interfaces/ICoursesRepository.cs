using School.Data.Dtos;

namespace School.ApplicationCore.Interfaces;

public interface ICoursesRepository
{
    Task<IReadOnlyCollection<CourseDto>> GetAllCourses();
}


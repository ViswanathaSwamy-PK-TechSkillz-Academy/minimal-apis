using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School.API.ApplicationCore.Interfaces;
using School.API.Data.DTOs;
using School.API.Persistence;

namespace School.API.Repositories;

public class CoursesRepository(SchoolDbContext schoolDbContext, IMapper mapper, ILogger<CoursesRepository> logger) : ICoursesRepository
{
    private readonly SchoolDbContext _schoolDbContext = schoolDbContext ?? throw new ArgumentNullException(nameof(schoolDbContext));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    private readonly ILogger<CoursesRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<IReadOnlyCollection<CourseDto>> GetAllCourses()
    {
        _logger.LogInformation($"Starting CoursesRepository::GetAllCourses()");

        return _mapper.Map<IReadOnlyCollection<CourseDto>>(await _schoolDbContext.Courses.ToListAsync());
    }

}

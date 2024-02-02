using Microsoft.EntityFrameworkCore;
using School.API.Data.Entities;
using School.API.Persistence.SeedData;

namespace School.API.Persistence;

public class SchoolDbContext(DbContextOptions<SchoolDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses => Set<Course>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new CourseData());
    }
}

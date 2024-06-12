using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entities;

namespace School.Persistence.SeedData;

internal class CourseData : IEntityTypeConfiguration<Course>
{

    public void Configure(EntityTypeBuilder<Course> builder)
    {
        _ = builder.HasData(
            new
            {
                Id = Guid.NewGuid(),
                Title = "Minimal API Development",
                Credits = 3,
                Duration = 3,
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedBy = "Admin",
                ModifiedDate = DateTimeOffset.UtcNow,
                ModifiedBy = "Admin"
            },
            new
            {
                Id = Guid.NewGuid(),
                Title = "Ultimate API Development",
                Credits = 5,
                Duration = 5,
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedBy = "Admin",
                ModifiedDate = DateTimeOffset.UtcNow,
                ModifiedBy = "Admin"
            }
        );
    }

}

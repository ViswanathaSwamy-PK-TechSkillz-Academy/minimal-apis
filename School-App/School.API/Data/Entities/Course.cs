namespace School.API.Data.Entities;

public class Course : BaseEntity
{
    public required Guid CourseId { get; set; }

    public required string? Name { get; set; }

    public int Duration { get; set; }

    public string? Description { get; set; }

    public string? PictureUrl { get; set; }
}

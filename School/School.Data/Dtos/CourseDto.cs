namespace School.Data.Dtos;

public record CourseDto
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public int Credits { get; set; }

    public int Duration { get; set; }

    public string? Description { get; set; }
}

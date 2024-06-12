namespace School.Data.Dtos;

public class CourseDto
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public int Credits { get; set; }

    public int Duration { get; set; }

    public string? Description { get; set; }
}

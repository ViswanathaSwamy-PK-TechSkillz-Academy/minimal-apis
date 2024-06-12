namespace School.Data.Entities;

public class Course : BaseEntity
{
    public string? Title { get; set; }

    public int Credits { get; set; }

    public int Duration { get; set; }

    public string? Description { get; set; }
}

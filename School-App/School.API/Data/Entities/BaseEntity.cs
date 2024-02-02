using System.ComponentModel.DataAnnotations;

namespace School.API.Data.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }

    public required DateTimeOffset CreatedDate { get; set; }

    public required string? CreatedBy { get; set; }

    public required DateTimeOffset ModifiedDate { get; set; }

    public required string? ModifiedBy { get; set; }
}

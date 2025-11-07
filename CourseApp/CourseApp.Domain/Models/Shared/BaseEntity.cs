namespace CourseApp.Domain.Models.Shared;

public class BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}

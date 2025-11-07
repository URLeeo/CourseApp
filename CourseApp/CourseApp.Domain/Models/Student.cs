using CourseApp.Domain.Models.Shared;

namespace CourseApp.Domain.Models;

public class Student : BaseEntity
{
    public string Surname { get; set; }
    public int Age { get; set; }
    public int GroupId { get; set; }
    public CourseGroup Group { get; set; }
}

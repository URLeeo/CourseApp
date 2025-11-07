using CourseApp.Domain.Models.Shared;

namespace CourseApp.Domain.Models;

public class Student : BaseEntity
{
    public string Surname { get; set; }
    public int Age { get; set; }
    public Group Group { get; set; }
}

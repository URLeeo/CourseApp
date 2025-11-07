using CourseApp.Domain.Models.Shared;

namespace CourseApp.Domain.Models;

public class CourseGroup : BaseEntity
{
    public string TeacherName { get; set; }
    public string Room { get; set; }
}

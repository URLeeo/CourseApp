using CourseApp.Domain.Models.Shared;

namespace CourseApp.Domain.Models;

public class CourseGroup : BaseEntity
{
    public string TeacherName { get; set; }
    public string Room { get; set; }
    public static int _id;
    public CourseGroup()
    {
        Id = _id;
        _id++;
    }
}

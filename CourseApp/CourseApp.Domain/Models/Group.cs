using CourseApp.Domain.Models.Shared;

namespace CourseApp.Domain.Models;

public class Group : BaseEntity
{
    public string Teacher { get; set; }
    public string Room { get; set; }
}

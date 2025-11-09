using CourseApp.Domain.Models;

namespace CourseApp.Service.Services.Interfaces;

public interface ICourseGroupService
{
    void Create(CourseGroup courseGroup);
    void Update(int id, CourseGroup courseGroup);
    void Delete(int id);
    CourseGroup GetById(int id);
    List<CourseGroup> GetAll();
    List<CourseGroup> GetAllByTeacherName(string teacherName);
    List<CourseGroup> GetAllByRoom(string room);
    List<CourseGroup> SearchByName(string name);
}

using CourseApp.Domain.Models;

namespace CourseApp.Service.Services.Interfaces;

public interface IStudentService
{
    Student Create(Student student);
    void Update(int id, Student student);
    void Delete(int id);
    Student GetById(int id);
    List<Student> GetAll();
    List<Student> GetAllByAge(int age);
    List<Student> GetAllByGroupId(int groupId);
    List<Student> SearchByNameOrSurname(string keyword);
}

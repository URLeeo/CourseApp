using CourseApp.Domain.Models;
using CourseApp.Repository.Repositories.Interfaces;

namespace CourseApp.Repository.Repositories.Services;

public class StudentRepository : IStudentRepository
{
    public void Create(Student entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetAll(Predicate<Student?> predicate = null)
    {
        throw new NotImplementedException();
    }

    public Student GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Student entity)
    {
        throw new NotImplementedException();
    }
}

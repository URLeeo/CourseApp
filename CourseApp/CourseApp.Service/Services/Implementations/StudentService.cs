using CourseApp.Domain.Models;
using CourseApp.Repository.Repositories.Interfaces;
using CourseApp.Service.Exceptions;
using CourseApp.Service.Services.Interfaces;

namespace CourseApp.Service.Services.Implementations;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseGroupService _groupService;
    public StudentService(IStudentRepository studentRepository, ICourseGroupService groupService)
    {
        _studentRepository = studentRepository;
        _groupService = groupService;
    }
    public void Create(int groupId, Student student)
    {
        var group = _groupService.GetById(groupId);
        if (group == null)
            throw new NotFoundException("There is no group with given ID! Create a new group!");

        if (student == null)
            throw new ArgumentNullException("Student cannot be null!");

        student.CourseGroup = group;
        _studentRepository.Create(student);
    }

    public void Delete(int id)
    {
        if (id < 0)
            throw new ArgumentNegativeException("Id has to be positive numbers!");

        _studentRepository.Delete(id);
    }

    public List<Student> GetAll()
    {
        return _studentRepository.GetAll();
    }

    public List<Student> GetAllByAge(int age)
    {
        if (age < 0)
            throw new ArgumentNegativeException("Age has to be positive numbers!");

        var students = _studentRepository.GetAll(s => s != null && s.Age == age);
        if (!students.Any())
            throw new EmptyListException("No students found with the given age.");

        return students;
    }

    public List<Student> GetAllByGroupId(int groupId)
    {
        if (groupId < 0)
            throw new ArgumentNegativeException("Group ID has to be positive numbers!");

        var students = _studentRepository.GetAll(s => s != null && s.CourseGroup != null && s.CourseGroup.Id == groupId);
        if (!students.Any())
            throw new EmptyListException("No students found in the given group.");

        return students;
    }

    public Student GetById(int id)
    {
        var student = _studentRepository.GetById(id);
        if (student == null)
            throw new NotFoundException("There is no student with given ID!");

        return student;
    }

    public List<Student> SearchByNameOrSurname(string keyword)
    {
        var students = _studentRepository.GetAll(s =>
            s != null &&
            (s.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
             s.Surname.Contains(keyword, StringComparison.OrdinalIgnoreCase)));

        if (!students.Any())
            throw new EmptyListException("No students found with the given keyword.");

        return students;
    }

    public void Update(int id, Student student)
    {
        if (id < 0)
            throw new ArgumentNegativeException("Id has to be positive numbers!");
        if (student == null)
            throw new ArgumentNullException("Student cannot be null!");

        var existingStudent = _studentRepository.GetById(id);
        if (existingStudent == null)
            throw new NotFoundException("Student not found!");

        if (!string.IsNullOrWhiteSpace(student.Name))
            existingStudent.Name = student.Name;

        if (!string.IsNullOrWhiteSpace(student.Surname))
            existingStudent.Surname = student.Surname;

        if (student.Age > 0)
            existingStudent.Age = student.Age;

        if (student.CourseGroup != null)
        {
            var group = _groupService.GetById(student.CourseGroup.Id);
            if (group == null)
                throw new NotFoundException("The provided CourseGroup does not exist!");

            existingStudent.CourseGroup = group;
        }

        _studentRepository.Update(id, existingStudent);
    }
}

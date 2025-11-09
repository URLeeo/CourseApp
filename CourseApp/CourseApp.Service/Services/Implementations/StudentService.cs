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
        try
        {
            var group = _groupService.GetById(groupId);
            if (group != null)
            {
                student.CourseGroup = group;
                try
                {
                    if (student is not null)
                    {
                        _studentRepository.Create(student);
                    }
                    else
                    {
                        throw new ArgumentNullException("Student cannot be null!");
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                throw new NotFoundException("There is no group with given ID!");
            }
        }
        catch (NotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Delete(int id)
    {
        try
        {
            if (id >= 0)
            {
                _studentRepository.Delete(id);
            }
            else
            {
                throw new ArgumentNegativeException("Id has to be positive numbers!");
            }
        }
        catch (ArgumentNegativeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public List<Student> GetAll()
    {
        List<Student> students = _studentRepository.GetAll();
        return students;
    }

    public List<Student> GetAllByAge(int age)
    {
        try
        {
            if (age >= 0)
            {
                List<Student> students = _studentRepository.GetAll(s => s != null && s.Age == age);
                return students;
            }
            else
            {
                throw new ArgumentNegativeException("Age has to be positive numbers!");
            }
        }
        catch (ArgumentNegativeException ex)
        {
            Console.WriteLine(ex.Message);
            return new List<Student>();
        }
    }

    public List<Student> GetAllByGroupId(int groupId)
    {
        try
        {
            if (groupId >= 0)
            {
                List<Student> students = _studentRepository.GetAll(s => s != null && s.CourseGroup != null && s.CourseGroup.Id == groupId);
                return students;
            }
            else
            {
                throw new ArgumentNegativeException("Group ID has to be positive numbers!");
            }
        }
        catch (ArgumentNegativeException ex)
        {
            Console.WriteLine(ex.Message);
            return new List<Student>();
        }
    }

    public Student GetById(int id)
    {
        var student = _studentRepository.GetById(id);
        try
        {
            if (student == null)
            {
                throw new NotFoundException("There is no student with given ID!");
            }
        }
        catch (NotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return student;
    }

    public List<Student> SearchByNameOrSurname(string keyword)
    {
        List<Student> students = _studentRepository.GetAll(s =>
        s != null &&
        (s.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
        s.Surname.Contains(keyword, StringComparison.OrdinalIgnoreCase)));
        try
        {
            if (students.Count == 0)
            {
                throw new EmptyListException("No students found with the given keyword.");
            }
        }
        catch (EmptyListException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return students;
    }

    public void Update(int id, Student student)
    {
        try
        {
            if (id >= 0 && student is not null)
            {
                _studentRepository.Update(id, student);
            }
            else if (id < 0)
            {
                throw new ArgumentNegativeException("Id has to be positive numbers!");
            }
            else
            {
                throw new ArgumentNullException("Student cannot be null!");
            }
        }
        catch (ArgumentNegativeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

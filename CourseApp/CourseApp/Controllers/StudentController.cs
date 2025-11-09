using CourseApp.Domain.Models;
using CourseApp.Service.Helpers;
using CourseApp.Service.Services.Implementations;

namespace CourseApp.Presentation.Controllers;

public class StudentController
{
    public void CreateStudent(StudentService studentService)
    {
        string name = Helper.ReadValidatedString("Invalid name! Enter again:");
        string surname = Helper.ReadValidatedString("Invalid surname! Enter again:");
        int age = Helper.ReadValidatedInt("Enter age:");
        int groupId = Helper.ReadValidatedInt("Enter group ID:");

        studentService.Create(groupId, new Student { Name = name, Surname = surname, Age = age });
        Helper.ColorWrite(ConsoleColor.Green, "Student created successfully!");
    }

    public void UpdateStudent(StudentService studentService)
    {
        int id = Helper.ReadValidatedInt("Enter student ID to update:");
        Console.Write("Enter new name: ");
        string newName = Console.ReadLine();
        Console.Write("Enter new surname: ");
        string newSurname = Console.ReadLine();
        int newAge = Helper.ReadValidatedInt("Enter new age:");

        studentService.Update(id, new Student { Name = newName, Surname = newSurname, Age = newAge });
        Helper.ColorWrite(ConsoleColor.Green, "Student updated successfully!");
    }

    public void DeleteStudent(StudentService studentService)
    {
        int id = Helper.ReadValidatedInt("Enter student ID to delete:");
        studentService.Delete(id);
        Helper.ColorWrite(ConsoleColor.Green, "Student deleted successfully!");
    }

    public void GetStudentById(StudentService studentService)
    {
        int id = Helper.ReadValidatedInt("Enter student ID:");
        var student = studentService.GetById(id);
        if (student != null)
            Console.WriteLine($"{student.Id}. {student.Name} {student.Surname} | Age: {student.Age} | Group: {student.CourseGroup?.Name}");
        else
            Helper.ColorWrite(ConsoleColor.Red, "Student not found!");
    }

    public void GetAllStudents(StudentService studentService)
    {
        var list = studentService.GetAll();
        foreach (var s in list)
            Console.WriteLine($"{s.Id}. {s.Name} {s.Surname} | {s.Age} | Group: {s.CourseGroup?.Name}");
    }

    public void GetStudentsByAge(StudentService studentService)
    {
        int age = Helper.ReadValidatedInt("Enter age:");
        var list = studentService.GetAllByAge(age);
        foreach (var s in list)
            Console.WriteLine($"{s.Id}. {s.Name} {s.Surname} | Age: {s.Age}");
    }

    public void GetStudentsByGroup(StudentService studentService)
    {
        int groupId = Helper.ReadValidatedInt("Enter group ID:");
        var list = studentService.GetAllByGroupId(groupId);
        foreach (var s in list)
            Console.WriteLine($"{s.Id}. {s.Name} {s.Surname}");
    }

    public void SearchStudents(StudentService studentService)
    {
        Console.Write("Enter keyword: ");
        string keyword = Console.ReadLine();
        var list = studentService.SearchByNameOrSurname(keyword);
        foreach (var s in list)
            Console.WriteLine($"{s.Id}. {s.Name} {s.Surname} | Age: {s.Age}");
    }
}

using CourseApp.Domain.Models;
using CourseApp.Service.Helpers;
using CourseApp.Service.Services.Implementations;

namespace CourseApp.Presentation.Controllers;

public class StudentController
{
    public void CreateStudent(StudentService studentService)
    {
        Console.WriteLine("=== Create New Student ===");
        Console.Write("Enter student name: ");
        string name = Helper.ReadValidatedString("Name is not valid. Enter again:");
        Console.Write("Enter student surname: ");
        string surname = Helper.ReadValidatedString("Surname is not valid. Enter again:");
        Console.Write("Enter student age: ");
        int age = Helper.ReadValidatedInt("Age must be a valid number. Enter again:");
        Console.Write("Enter group ID: ");
        int groupId = Helper.ReadValidatedInt("Group ID must be a valid number. Enter again:");


        try
        {
            studentService.Create(groupId, new Student { Name = name, Surname = surname, Age = age });
            Helper.ColorWrite(ConsoleColor.Green, "Student created successfully!");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void UpdateStudent(StudentService studentService)
    {
        Console.WriteLine("=== Update Student ===");
        Console.Write("Enter student ID to update: ");
        int id = Helper.ReadValidatedInt("ID must be a valid number. Enter again:");
        Console.Write("Enter new student name: ");
        string newName = Helper.ReadValidatedString("Name is not valid. Enter again:");
        Console.Write("Enter new student surname: ");
        string newSurname = Helper.ReadValidatedString("Surname is not valid. Enter again:");
        Console.Write("Enter new student age: ");
        int newAge = Helper.ReadValidatedInt("Age must be a valid number. Enter again:");

        try
        {
            studentService.Update(id, new Student { Name = newName, Surname = newSurname, Age = newAge });
            Helper.ColorWrite(ConsoleColor.Green, "Student updated successfully!");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void DeleteStudent(StudentService studentService)
    {
        Console.WriteLine("=== Delete Student ===");
        Console.Write("Enter student ID to delete: ");
        int id = Helper.ReadValidatedInt("ID must be a valid number. Enter again:");

        try
        {
            studentService.Delete(id);
            Helper.ColorWrite(ConsoleColor.Green, "Student deleted successfully!");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetStudentById(StudentService studentService)
    {
        Console.WriteLine("=== View Student Details ===");
        Console.Write("Enter student ID: ");
        int id = Helper.ReadValidatedInt("ID must be a valid number. Enter again:");

        try
        {
            var student = studentService.GetById(id);
            Console.WriteLine($"ID: {student.Id} | Name: {student.Name} {student.Surname} | Age: {student.Age} | Group: {student.CourseGroup?.Name}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetAllStudents(StudentService studentService)
    {
        Console.WriteLine("=== List All Students ===");

        try
        {
            var list = studentService.GetAll();
            foreach (var s in list)
                Console.WriteLine($"ID: {s.Id} | Name: {s.Name} {s.Surname} | Age: {s.Age} | Group: {s.CourseGroup?.Name}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetStudentsByAge(StudentService studentService)
    {
        Console.WriteLine("=== List Students by Age ===");
        Console.Write("Enter age: ");
        int age = Helper.ReadValidatedInt("Age must be a valid number. Enter again:");

        try
        {
            var list = studentService.GetAllByAge(age);
            foreach (var s in list)
                Console.WriteLine($"ID: {s.Id} | Name: {s.Name} {s.Surname} | Age: {s.Age}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetStudentsByGroup(StudentService studentService)
    {
        Console.WriteLine("=== List Students by Group ===");
        Console.Write("Enter group ID: ");
        int groupId = Helper.ReadValidatedInt("Group ID must be a valid number. Enter again:");

        try
        {
            var list = studentService.GetAllByGroupId(groupId);
            foreach (var s in list)
                Console.WriteLine($"ID: {s.Id} | Name: {s.Name} {s.Surname}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void SearchStudents(StudentService studentService)
    {
        Console.WriteLine("=== Search Students ===");
        Console.Write("Enter keyword (name or surname): ");
        string keyword = Console.ReadLine();

        try
        {
            var list = studentService.SearchByNameOrSurname(keyword);
            foreach (var s in list)
                Console.WriteLine($"ID: {s.Id} | Name: {s.Name} {s.Surname} | Age: {s.Age}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }
}

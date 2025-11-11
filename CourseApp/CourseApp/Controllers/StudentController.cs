using CourseApp.Domain.Models;
using CourseApp.Service.Helpers;
using CourseApp.Service.Services.Implementations;

namespace CourseApp.Presentation.Controllers;

public class StudentController
{
    public void CreateStudent(StudentService studentService)
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "=== Create New Student ===");

        Console.Write("Enter student name: ");
        string name = Helper.ReadValidatedString("Name is not valid. Enter again:");

        Console.Write("Enter student surname: ");
        string surname = Helper.ReadValidatedString("Surname is not valid. Enter again:");

        int age;
        while (true)
        {
            Console.Write("Enter student age: ");
            age = Helper.ReadValidatedInt("Age must be a valid number. Enter again:");
            if (age >= 8 && age <= 70)
                break;
            Helper.ColorWrite(ConsoleColor.Red, "Age must be between 8 and 70. Enter again:");
        }

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
        Helper.ColorWrite(ConsoleColor.Cyan, "=== Update Student ===");

        Console.Write("Enter student ID to update: ");
        int id = Helper.ReadValidatedInt("ID must be a valid number. Enter again:");

        Student existingStudent = null;
        try
        {
            existingStudent = studentService.GetById(id);
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
            return;
        }

        Console.WriteLine($"Current Name: {existingStudent.Name}");
        Console.Write("Enter new student name (leave empty to keep current): ");
        string newName = Helper.ReadValidatedUpdateString(existingStudent.Name, "Name is not valid. Enter again:");

        Console.WriteLine($"Current Surname: {existingStudent.Surname}");
        Console.Write("Enter new student surname (leave empty to keep current): ");
        string newSurname = Helper.ReadValidatedUpdateString(existingStudent.Surname, "Surname is not valid. Enter again:");

        int newAge;
        while (true)
        {
            Console.WriteLine($"Current Age: {existingStudent.Age}");
            Console.Write("Enter new student age (leave empty to keep current): ");
            string ageInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ageInput))
            {
                newAge = existingStudent.Age;
                break;
            }

            if (int.TryParse(ageInput, out newAge) && newAge >= 8 && newAge <= 70)
                break;

            Helper.ColorWrite(ConsoleColor.Red, "Age must be a number between 8 and 70. Enter again:");
        }

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
        Helper.ColorWrite(ConsoleColor.Cyan, "=== Delete Student ===");
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
        Helper.ColorWrite(ConsoleColor.Cyan, "=== View Student Details ===");
        Console.Write("Enter student ID: ");
        int id = Helper.ReadValidatedInt("ID must be a valid number. Enter again:");

        try
        {
            var student = studentService.GetById(id);
            Helper.ColorWrite(ConsoleColor.Green, $"ID: {student.Id} | Name: {student.Name} {student.Surname} | Age: {student.Age} | Group: {student.CourseGroup?.Name}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetAllStudents(StudentService studentService)
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "=== List All Students ===");

        try
        {
            var list = studentService.GetAll();
            foreach (var s in list)
                Helper.ColorWrite(ConsoleColor.Green, $"ID: {s.Id} | Name: {s.Name} {s.Surname} | Age: {s.Age} | Group: {s.CourseGroup?.Name}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetStudentsByAge(StudentService studentService)
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "=== List Students by Age ===");
        Console.Write("Enter age: ");
        int age = Helper.ReadValidatedInt("Age must be a valid number. Enter again:");

        try
        {
            var list = studentService.GetAllByAge(age);
            foreach (var s in list)
                Helper.ColorWrite(ConsoleColor.Green, $"ID: {s.Id} | Name: {s.Name} {s.Surname} | Age: {s.Age}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetStudentsByGroup(StudentService studentService)
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "=== List Students by Group ===");
        Console.Write("Enter group ID: ");
        int groupId = Helper.ReadValidatedInt("Group ID must be a valid number. Enter again:");

        try
        {
            var list = studentService.GetAllByGroupId(groupId);
            foreach (var s in list)
                Helper.ColorWrite(ConsoleColor.Green, $"ID: {s.Id} | Name: {s.Name} {s.Surname}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void SearchStudents(StudentService studentService)
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "=== Search Students ===");
        Console.Write("Enter keyword (name or surname): ");
        string keyword = Console.ReadLine();

        try
        {
            var list = studentService.SearchByNameOrSurname(keyword);
            foreach (var s in list)
                Helper.ColorWrite(ConsoleColor.Green, $"ID: {s.Id} | Name: {s.Name} {s.Surname} | Age: {s.Age}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }
}
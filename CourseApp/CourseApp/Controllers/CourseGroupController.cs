using CourseApp.Domain.Models;
using CourseApp.Service.Exceptions;
using CourseApp.Service.Helpers;
using CourseApp.Service.Services.Implementations;

namespace CourseApp.Presentation.Controllers;

public class CourseGroupController
{
    public void CreateCourseGroup(CourseGroupService groupService)
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "=== Create New Course Group ===");

        Console.WriteLine("Enter group name:");
        string name = Helper.ReadLetterOrDigitString("Group name is not valid. Enter again:");

        Console.WriteLine("Enter teacher name:");
        string teacher = Helper.ReadValidatedString("Teacher name is not valid. Enter again:");

        Console.WriteLine("Enter room:");
        string room = Helper.ReadLetterOrDigitString("Room cannot be empty. Enter again:");

        try
        {
            groupService.Create(new CourseGroup { Name = name, TeacherName = teacher, Room = room });
            Helper.ColorWrite(ConsoleColor.Green, "Group created successfully!");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void UpdateCourseGroup(CourseGroupService groupService)
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "=== Update Course Group ===");

        Console.WriteLine("Enter group ID to update");
        int id = Helper.ReadValidatedInt("ID must be a valid number. Enter again:");

        CourseGroup existingGroup;
        try
        {
            existingGroup = groupService.GetById(id);
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
            return;
        }

        Console.WriteLine($"Current Name: {existingGroup.Name}");
        Console.Write("Enter new name (leave empty to keep current): ");
        string newName = Helper.ReadLetterOrDigitUpdateString(existingGroup.Name, "Name is not valid. Enter again:");

        Console.WriteLine($"Current Teacher: {existingGroup.TeacherName}");
        Console.Write("Enter new teacher name (leave empty to keep current): ");
        string newTeacher = Helper.ReadValidatedUpdateString(existingGroup.TeacherName, "Teacher name is not valid. Enter again:");

        Console.WriteLine($"Current Room: {existingGroup.Room}");
        Console.Write("Enter new room (leave empty to keep current): ");
        string newRoom = Helper.ReadLetterOrDigitUpdateString(existingGroup.Room, "Room is not valid. Enter again:");

        try
        {
            groupService.Update(id, new CourseGroup
            {
                Name = newName,
                TeacherName = newTeacher,
                Room = newRoom
            });
            Helper.ColorWrite(ConsoleColor.Green, "Group updated successfully!");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }


    public void DeleteCourseGroup(CourseGroupService groupService)
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "=== Delete Course Group ===");
        Console.Write("Enter group ID to delete: ");
        int id = Helper.ReadValidatedInt("ID must be a valid number. Enter again:");

        try
        {
            groupService.Delete(id);
            Helper.ColorWrite(ConsoleColor.Green, "Group deleted successfully!");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetCourseGroupById(CourseGroupService groupService)
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "=== View Course Group Details ===");
        Console.Write("Enter group ID to get: ");
        int id = Helper.ReadValidatedInt("ID must be a valid number. Enter again:");

        try
        {
            var group = groupService.GetById(id);
            Helper.ColorWrite(ConsoleColor.Green, $"ID: {group.Id} | Name: {group.Name} | Teacher: {group.TeacherName} | Room: {group.Room}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetAllCourseGroups(CourseGroupService groupService)
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "=== List All Course Groups ===");
        try
        {
            var all = groupService.GetAll();
            foreach (var g in all)
                Helper.ColorWrite(ConsoleColor.Green, $"ID: {g.Id}. Name: {g.Name} | Teacher: {g.TeacherName} | Room: {g.Room}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetCourseGroupsByTeacher(CourseGroupService groupService)
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "=== List Course Groups by Teacher ===");
        Console.WriteLine("Enter teacher name:");
        string teacher = Console.ReadLine();

        try
        {
            var list = groupService.GetAllByTeacherName(teacher);
            foreach (var g in list)
                Helper.ColorWrite(ConsoleColor.Green, $"ID: {g.Id}. Name: {g.Name} | Teacher: {g.TeacherName}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetCourseGroupsByRoom(CourseGroupService groupService)
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "=== List Course Groups by Room ===");
        Console.WriteLine("Enter room:");
        string room = Console.ReadLine();

        try
        {
            var list = groupService.GetAllByRoom(room);
            foreach (var g in list)
                Helper.ColorWrite(ConsoleColor.Green, $"ID: {g.Id}. Name: {g.Name} | Room: {g.Room}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void SearchCourseGroupsByName(CourseGroupService groupService)
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "=== Search Course Groups by Name ===");
        Console.WriteLine("Enter keyword:");
        string keyword = Console.ReadLine();

        try
        {
            var list = groupService.SearchByName(keyword);
            foreach (var g in list)
                Helper.ColorWrite(ConsoleColor.Green, $"ID: {g.Id}. Name: {g.Name} | Teacher: {g.TeacherName} | Room: {g.Room}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }
}

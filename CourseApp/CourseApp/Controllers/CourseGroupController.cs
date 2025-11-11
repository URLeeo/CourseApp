using CourseApp.Domain.Models;
using CourseApp.Service.Helpers;
using CourseApp.Service.Services.Implementations;

namespace CourseApp.Presentation.Controllers;

public class CourseGroupController
{
    public void CreateCourseGroup(CourseGroupService groupService)
    {
        Console.Write("Enter group name: ");
        string name = Helper.ReadLetterOrDigitString("Group name is not valid. Enter again:");
        Console.Write("Enter teacher name: ");
        string teacher = Helper.ReadValidatedString("Teacher name is not valid. Enter again:");
        Console.Write("Enter room: ");
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
        int id = Helper.ReadValidatedInt("Enter ID to update:");
        Console.Write("Enter new name: ");
        string newName = Console.ReadLine();
        Console.Write("Enter new teacher name: ");
        string newTeacher = Console.ReadLine();
        Console.Write("Enter new room: ");
        string newRoom = Console.ReadLine();

        try
        {
            groupService.Update(id, new CourseGroup { Name = newName, TeacherName = newTeacher, Room = newRoom });
            Helper.ColorWrite(ConsoleColor.Green, "Group updated successfully!");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void DeleteCourseGroup(CourseGroupService groupService)
    {
        int id = Helper.ReadValidatedInt("Enter ID to delete:");

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
        int id = Helper.ReadValidatedInt("Enter group ID:");

        try
        {
            var group = groupService.GetById(id);
            Console.WriteLine($"ID: {group.Id} | Name: {group.Name} | Teacher: {group.TeacherName} | Room: {group.Room}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetAllCourseGroups(CourseGroupService groupService)
    {
        try
        {
            var all = groupService.GetAll();
            foreach (var g in all)
                Console.WriteLine($"ID: {g.Id}. Name: {g.Name} | Teacher: {g.TeacherName} | Room: {g.Room}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetCourseGroupsByTeacher(CourseGroupService groupService)
    {
        Console.Write("Enter teacher name: ");
        string teacher = Console.ReadLine();

        try
        {
            var list = groupService.GetAllByTeacherName(teacher);
            foreach (var g in list)
                Console.WriteLine($"ID: {g.Id}. Name: {g.Name} | Teacher: {g.TeacherName}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void GetCourseGroupsByRoom(CourseGroupService groupService)
    {
        Console.Write("Enter room: ");
        string room = Console.ReadLine();

        try
        {
            var list = groupService.GetAllByRoom(room);
            foreach (var g in list)
                Console.WriteLine($"ID: {g.Id}. Name: {g.Name} | Room: {g.Room}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }

    public void SearchCourseGroupsByName(CourseGroupService groupService)
    {
        Console.Write("Enter keyword: ");
        string keyword = Console.ReadLine();

        try
        {
            var list = groupService.SearchByName(keyword);
            foreach (var g in list)
                Console.WriteLine($"ID: {g.Id}. Name: {g.Name} | Teacher: {g.TeacherName} | Room: {g.Room}");
        }
        catch (Exception ex)
        {
            Helper.ColorWrite(ConsoleColor.Red, ex.Message);
        }
    }
}

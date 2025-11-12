using CourseApp.Domain.Models;
using CourseApp.Presentation.Controllers;
using CourseApp.Repository.Repositories.Services;
using CourseApp.Service.Enums;
using CourseApp.Service.Enumsl;
using CourseApp.Service.Helpers;
using CourseApp.Service.Services.Implementations;
using System.Text.RegularExpressions;

namespace CourseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper.PlayWelcomeSound();
            CourseGroupRepository groupRepository = new();
            StudentRepository studentRepository = new();
            CourseGroupService groupService = new(groupRepository);
            StudentService studentService = new(studentRepository, groupService);
            StudentController studentController = new();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n========== MAIN MENU ==========");
                Console.WriteLine("1. Course Group Menu");
                Console.WriteLine("2. Student Menu");
                Console.WriteLine("0. Exit");
                Console.ResetColor();

            MainInput:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter your choice: ");
                Console.ResetColor();

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int mainChoice))
                {
                    Helper.ColorWrite(ConsoleColor.Red, "Input type is not correct! Please enter a number.");
                    goto MainInput;
                }

                switch (mainChoice)
                {
                    case 1:
                        Helper.PlaySelectSound();
                        CourseGroupMenu(groupService);
                        break;
                    case 2:
                        Helper.PlaySelectSound();
                        StudentMenu(studentService, groupService);
                        break;
                    case 0:
                        Helper.PlayExitSound();
                        Helper.ColorWrite(ConsoleColor.Green, "Goodbye!");
                        return;
                    default:
                        Helper.ColorWrite(ConsoleColor.Red, "Invalid menu choice!");
                        goto MainInput;
                }
            }
        }

        static void CourseGroupMenu(CourseGroupService groupService)
        {
            while (true)
            {
                CourseGroupController courseGroupController = new CourseGroupController();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n====== COURSE GROUP MENU ======");
                Console.WriteLine("1. Create");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. GetById");
                Console.WriteLine("5. GetAll");
                Console.WriteLine("6. GetAllByTeacherName");
                Console.WriteLine("7. GetAllByRoom");
                Console.WriteLine("8. SearchByName");
                Console.WriteLine("0. Back");
                Console.ResetColor();

            Input:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter your choice: ");
                Console.ResetColor();

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Helper.ColorWrite(ConsoleColor.Red, "Input type is not correct!");
                    goto Input;
                }
                switch (choice)
                {
                    case (int)CourseGroupMethods.Create:
                        courseGroupController.CreateCourseGroup(groupService);
                        break;
                    case (int)CourseGroupMethods.Update:
                        courseGroupController.UpdateCourseGroup(groupService);
                        break;
                    case (int)CourseGroupMethods.Delete:
                        courseGroupController.DeleteCourseGroup(groupService);
                        break;
                    case (int)CourseGroupMethods.GetById:
                        courseGroupController.GetCourseGroupById(groupService);
                        break;
                    case (int)CourseGroupMethods.GetAll:
                        courseGroupController.GetAllCourseGroups(groupService);
                        break;
                    case (int)CourseGroupMethods.GetAllByTeacherName:
                        courseGroupController.GetCourseGroupsByTeacher(groupService);
                        break;
                    case (int)CourseGroupMethods.GetAllByRoom:
                        courseGroupController.GetCourseGroupsByRoom(groupService);
                        break;
                    case (int)CourseGroupMethods.SearchByName:
                        courseGroupController.SearchCourseGroupsByName(groupService);
                        break;
                    case (int)CourseGroupMethods.Exit:
                        return;
                    default:
                        Helper.ColorWrite(ConsoleColor.Red, "Invalid choice!");
                        break;
                }
            }
        }



        static void StudentMenu(StudentService studentService, CourseGroupService groupService)
        {
            while (true)
            {
                StudentController studentController = new StudentController();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n========== STUDENT MENU ==========");
                Console.WriteLine("1. Create");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. GetById");
                Console.WriteLine("5. GetAll");
                Console.WriteLine("6. GetAllByAge");
                Console.WriteLine("7. GetAllByGroupId");
                Console.WriteLine("8. SearchByNameOrSurname");
                Console.WriteLine("0. Back");
                Console.ResetColor();

                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Helper.ColorWrite(ConsoleColor.Red, "Invalid input!");
                    continue;
                }

                switch (choice)
                {
                    case (int)StudentMethods.Create:
                        studentController.CreateStudent(studentService);
                        break;
                    case (int)StudentMethods.Delete:
                        studentController.DeleteStudent(studentService);
                        break;
                    case (int)StudentMethods.Update:
                        studentController.UpdateStudent(studentService);
                        break;
                    case (int)StudentMethods.GetById:
                        studentController.GetStudentById(studentService);
                        break;
                    case (int)StudentMethods.GetAll:
                        studentController.GetAllStudents(studentService);
                        break;
                    case (int)StudentMethods.GetAllByAge:
                        studentController.GetStudentsByAge(studentService);
                        break;
                    case (int)StudentMethods.GetAllByGroupId:
                        studentController.GetStudentsByGroup(studentService);
                        break;
                    case (int)StudentMethods.SearchByNameOrSurname:
                        studentController.SearchStudents(studentService);
                        break;
                    case (int)StudentMethods.Exit:
                        return;
                    default:
                        Helper.ColorWrite(ConsoleColor.Red, "Invalid choice!");
                        break;

                }
            }
        }
    }
}

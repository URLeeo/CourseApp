using CourseApp.Service.Helpers;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    private static void GetMenuOptions()
    {
        Helper.ColorWrite(ConsoleColor.Cyan, "Select an option from the menu:");
        Helper.ColorWrite(ConsoleColor.Yellow, "1. Manage Students");
        Helper.ColorWrite(ConsoleColor.Yellow, "2. Manage Course Groups");
        Helper.ColorWrite(ConsoleColor.Yellow, "0. Exit");
        Helper.ColorWrite(ConsoleColor.Cyan, "Enter your choice: ");
    }
    private static void ManageStudents()
    {
        // Implementation for managing students
    }
    private static void ManageCourseGroups()
    {
        // Implementation for managing course groups
    }
}

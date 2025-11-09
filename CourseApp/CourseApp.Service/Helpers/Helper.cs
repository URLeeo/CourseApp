namespace CourseApp.Service.Helpers;

public static class Helper
{
    public static void ColorWrite(ConsoleColor color,string text)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}

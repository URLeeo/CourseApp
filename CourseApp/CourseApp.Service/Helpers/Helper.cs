using System.Text.RegularExpressions;

namespace CourseApp.Service.Helpers;

public static class Helper
{
    public static void ColorWrite(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static string ReadValidatedString(string errorMsg)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
                return input;

            ColorWrite(ConsoleColor.Red, errorMsg);
        }
    }

    public static string ReadLetterOrDigitString(string errorMsg)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^[a-zA-Z0-9\s]+$"))
                return input;

            ColorWrite(ConsoleColor.Red, errorMsg);
        }
    }

    public static string ReadNonEmptyString(string errorMsg)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input;

            ColorWrite(ConsoleColor.Red, errorMsg);
        }
    }

    public static int ReadValidatedInt(string errorMsg)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result) && result >= 0)
                return result;

            ColorWrite(ConsoleColor.Red, errorMsg);
        }
    }

    public static string ReadValidatedUpdateString(string currentValue, string errorMsg)
    {
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
            return currentValue;

        if (Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
            return input;

        ColorWrite(ConsoleColor.Red, errorMsg);
        return ReadValidatedUpdateString(currentValue, errorMsg);
    }

    public static string ReadLetterOrDigitUpdateString(string currentValue, string errorMsg)
    {
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
            return currentValue;

        if (Regex.IsMatch(input, @"^[a-zA-Z0-9\s]+$"))
            return input;

        ColorWrite(ConsoleColor.Red, errorMsg);
        return ReadLetterOrDigitUpdateString(currentValue, errorMsg);
    }


    public static void PlayWelcomeSound()
    {
        Console.Beep(800, 150);
        Console.Beep(1000, 150);
        Console.Beep(1200, 150);
        Console.Beep(1000, 150);
        Console.Beep(800, 300);
    }

    public static void PlaySelectSound()
    {
        Console.Beep(1000, 150);
    }

    public static void PlayExitSound()
    {
        Console.Beep(2000, 300);
    }
}

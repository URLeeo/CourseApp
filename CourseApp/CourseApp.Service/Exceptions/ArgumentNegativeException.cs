namespace CourseApp.Service.Exceptions;

public class ArgumentNegativeException : Exception
{
    public ArgumentNegativeException(string message) : base(message)
    {
    }
}

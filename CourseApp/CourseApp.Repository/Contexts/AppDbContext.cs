namespace CourseApp.Repository.Contexts;

public class AppDbContext<T>
{
    public static List<T> Entities { get; set; }

    static AppDbContext()
    {
        Entities = new List<T>();
    }
}

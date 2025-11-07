namespace CourseApp.Repository.Repositories.Interfaces;

public interface IRepository<T>
{
    void Create(T entity);
    void Update(int id, T entity);
    void Delete(int id);
    T GetById(int id);
    List<T> GetAll(Predicate<T?> predicate = null);
}

using CourseApp.Domain.Models;
using CourseApp.Repository.Contexts;
using CourseApp.Repository.Repositories.Interfaces;

namespace CourseApp.Repository.Repositories.Services;

public class CourseGroupRepository : ICourseGroupRepository
{
    public void Create(CourseGroup entity)
    {
        AppDbContext<CourseGroup>.Entities.Add(entity);
    }

    public void Delete(int id)
    {
        var entity = AppDbContext<CourseGroup>.Entities.Find(cg => cg.Id == id);
        AppDbContext<CourseGroup>.Entities.Remove(entity);
    }

    public List<CourseGroup> GetAll(Predicate<CourseGroup?> predicate = null)
    {
        if (predicate == null)
        {
            return AppDbContext<CourseGroup>.Entities;
        }
        return AppDbContext<CourseGroup>.Entities.FindAll(predicate);
    }

    public CourseGroup GetById(int id)
    {
        return AppDbContext<CourseGroup>.Entities.Find(cg => cg.Id == id);
    }

    public void Update(int id, CourseGroup entity)
    {
        var existingEntity = AppDbContext<CourseGroup>.Entities.Find(cg => cg.Id == id);
        existingEntity.TeacherName = entity.TeacherName;
        existingEntity.Room = entity.Room;
    }
}

using CourseApp.Domain.Models;
using CourseApp.Repository.Repositories.Interfaces;
using CourseApp.Repository.Repositories.Services;
using CourseApp.Service.Exceptions;
using CourseApp.Service.Services.Interfaces;
using System.Xml.Linq;

namespace CourseApp.Service.Services.Implementations;

public class CourseGroupService : ICourseGroupService
{
    private readonly ICourseGroupRepository _groupRepository;
    public CourseGroupService(ICourseGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    public void Create(CourseGroup courseGroup)
    {
        try
        {
            if (courseGroup is not null)
            {
                _groupRepository.Create(courseGroup);
            }
            else
            {
                throw new ArgumentNullException("Course group cannot be null!");
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Delete(int id)
    {
        try
        {
            if (id >= 0)
            {
                _groupRepository.Delete(id);
            }
            else
            {
                throw new ArgumentNegativeException("Id has to be positive numbers!");
            }
        }
        catch (ArgumentNegativeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public List<CourseGroup> GetAll()
    {
        List<CourseGroup> courseGroups = _groupRepository.GetAll();
        return courseGroups;
    }
    public List<CourseGroup> GetAllByRoom(string room)
    {
        List<CourseGroup> courseGroups = _groupRepository.GetAll(cg => cg != null
        && cg.Name.Contains(room, StringComparison.OrdinalIgnoreCase));
        try
        {
            if (courseGroups.Count == 0)
            {
                throw new EmptyListException("No course groups found with the given room name.");
            }
        }
        catch (EmptyListException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return courseGroups;
    }

    public List<CourseGroup> GetAllByTeacherName(string teacherName)
    {
        List<CourseGroup> courseGroups = _groupRepository.GetAll(cg => cg != null
        && cg.Name.Contains(teacherName, StringComparison.OrdinalIgnoreCase));
        try
        {
            if (courseGroups.Count == 0)
            {
                throw new EmptyListException("No course groups found with the given teacher name.");
            }
        }
        catch (EmptyListException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return courseGroups;
    }

    public CourseGroup GetById(int id)
    {
        CourseGroup courseGroup = null;
        try
        {
            if (id >= 0)
            {
                courseGroup = _groupRepository.GetById(id);
            }
            else
            {
                throw new ArgumentNegativeException("Id has to be positive numbers!");
            }
        }
        catch (ArgumentNegativeException ex)
        {
            Console.WriteLine($"An error occurred while retrieving the course group: {ex.Message}");
        }
        return courseGroup;
    }

    public List<CourseGroup> SearchByName(string name)
    {
        List<CourseGroup> groups = _groupRepository.GetAll(s =>
        s != null &&
        s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        try
        {
            if (groups.Count == 0)
            {
                throw new EmptyListException("No groups found with the given keyword.");
            }
        }
        catch (EmptyListException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return groups;
    }

    public void Update(int id, CourseGroup courseGroup)
    {
        try
        {
            if (id >= 0 && courseGroup is not null)
            {
                _groupRepository.Update(id, courseGroup);
            }
            else if (id < 0)
            {
                throw new ArgumentNegativeException("Id has to be positive numbers!");
            }
            else
            {
                throw new ArgumentNullException("Course group cannot be null!");
            }
        }
        catch (ArgumentNegativeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

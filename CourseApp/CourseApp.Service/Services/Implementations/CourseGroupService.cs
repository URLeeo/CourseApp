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
        if (courseGroup is null)
            throw new ArgumentNullException("Course group cannot be null!");

        bool nameExists = _groupRepository.GetAll()
            .Any(g => g.Name.Equals(courseGroup.Name, StringComparison.OrdinalIgnoreCase));

        if (nameExists)
            throw new AlreadyExistsException($"A course group with name '{courseGroup.Name}' already exists!");

        _groupRepository.Create(courseGroup);
    }

    public void Delete(int id)
    {
        if (id < 0)
            throw new ArgumentNegativeException("Id has to be positive numbers!");

        var existingGroup = _groupRepository.GetById(id);
        if (existingGroup == null)
            throw new NotFoundException("Course group not found!");

        _groupRepository.Delete(id);
    }

    public List<CourseGroup> GetAll() => _groupRepository.GetAll();

    public List<CourseGroup> GetAllByRoom(string room)
    {
        var groups = _groupRepository.GetAll(cg =>
            cg != null &&
            !string.IsNullOrWhiteSpace(cg.Room) &&
            cg.Room.Contains(room, StringComparison.OrdinalIgnoreCase));

        if (groups.Count == 0)
            throw new EmptyListException("No course groups found with the given room name.");

        return groups;
    }

    public List<CourseGroup> GetAllByTeacherName(string teacherName)
    {
        var groups = _groupRepository.GetAll(cg =>
            cg != null &&
            !string.IsNullOrWhiteSpace(cg.TeacherName) &&
            cg.TeacherName.Contains(teacherName, StringComparison.OrdinalIgnoreCase));

        if (groups.Count == 0)
            throw new EmptyListException("No course groups found with the given teacher name.");

        return groups;
    }

    public CourseGroup GetById(int id)
    {
        if (id < 0)
            throw new ArgumentNegativeException("Id has to be positive numbers!");

        var group = _groupRepository.GetById(id);
        if (group == null)
            throw new NotFoundException("Course group not found!");

        return group;
    }

    public List<CourseGroup> SearchByName(string name)
    {
        var groups = _groupRepository.GetAll(cg =>
            cg != null &&
            !string.IsNullOrWhiteSpace(cg.Name) &&
            cg.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        if (groups.Count == 0)
            throw new EmptyListException("No groups found with the given keyword.");

        return groups;
    }

    public void Update(int id, CourseGroup courseGroup)
    {
        if (id < 0)
            throw new ArgumentNegativeException("Id has to be positive numbers!");
        if (courseGroup is null)
            throw new ArgumentNullException("Course group cannot be null!");

        var existingGroup = _groupRepository.GetById(id);
        if (existingGroup == null)
            throw new NotFoundException("Course group not found!");

        if (!string.IsNullOrWhiteSpace(courseGroup.Name))
        {
            bool nameExists = _groupRepository.GetAll()
                .Any(g => g.Id != id && g.Name.Equals(courseGroup.Name, StringComparison.OrdinalIgnoreCase));

            if (nameExists)
                throw new AlreadyExistsException($"A course group with name '{courseGroup.Name}' already exists!");

            existingGroup.Name = courseGroup.Name;
        }

        if (!string.IsNullOrWhiteSpace(courseGroup.TeacherName))
            existingGroup.TeacherName = courseGroup.TeacherName;

        if (!string.IsNullOrWhiteSpace(courseGroup.Room))
            existingGroup.Room = courseGroup.Room;

        _groupRepository.Update(id, existingGroup);
    }
}
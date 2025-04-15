using Domain.Dto;
using Domain.ValueObjects;

namespace Domain.Entities.Courses;

public class Teacher
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public string Name { get; private set; }

    public Discipline Discipline { get; private set; }

    public Teacher(string name, Discipline discipline)
    {
        this.Name = name;
        this.Discipline = discipline;
    }

    public Teacher(TeacherDto teacher)
    {
        this.Name = teacher.Name;
        this.Discipline = teacher.Discipline;
    }

    public Teacher()
    {
    }

    public Teacher DeepClone(string teacherId, Teacher teacher)
    {
        return new Teacher
        {
            Id = teacherId,
            Name = teacher.Name,
            Discipline = teacher.Discipline,
        };
    }
}
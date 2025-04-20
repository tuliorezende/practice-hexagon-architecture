using Domain.Shared;

namespace Infra.Database.SqlServer.Courses.Entities;

public class Teacher
{
    public string Id { get; private set; }

    public string Name { get; private set; }

    public Discipline Discipline { get; private set; }

    public List<Course>? Courses { get; private set; }

    // public Teacher(string id, string name, Discipline discipline, List<Course>? courses)
    // {
    //     this.Id = id;
    //     this.Name = name;
    //     this.Discipline = discipline;
    //     this.Courses = courses ?? new List<Course>();
    // }

    public void Update(string teacherId, Domain.Courses.Entities.Teacher teacher)
    {
        this.Id = teacherId;
        this.Name = teacher.Name;
        this.Discipline = teacher.Discipline;
    }

    public Teacher(string id, string name, Discipline discipline)
    {
        this.Id = id;
        this.Name = name;
        this.Discipline = discipline;
    }
}
using Domain.Shared;

namespace Infra.Database.SqlServer.Courses.Entities;

public class Teacher
{
    public string Id { get; set; }

    public string Name { get; set; }

    public Discipline Discipline { get; set; }

    public List<Course>? Courses { get; set; }

    public void Update(string teacherId, Domain.Courses.Entities.Teacher teacher)
    {
        this.Id = teacherId;
        this.Name = teacher.Name;
        this.Discipline = teacher.Discipline;
    }

    public Teacher()
    {
        
    }
    
    // public Teacher(string id, string name, Discipline discipline)
    // {
    //     this.Id = id;
    //     this.Name = name;
    //     this.Discipline = discipline;
    // }
    //
    // public Teacher()
    // {
    // }
}
using Domain.Shared;

namespace Infra.Database.SqlServer.Courses.Entities;

public class Course
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Discipline Discipline { get; set; }

    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset EndDate { get; set; }

    public string? TeacherId { get; set; }

    public Teacher Teacher { get; set; }

    public List<ClassMaterialEntry> Materials { get; set; } = new List<ClassMaterialEntry>();

    public void Update(string courseId, Domain.Courses.Entities.Course course)
    {
        this.Id = courseId;
        this.Name = course.Name;
        this.Description = course.Description;
        this.Discipline = course.Discipline;
        this.StartDate = course.StartDate;
        this.EndDate = course.EndDate;
        this.TeacherId = course.TeacherId;
    }

    public Course()
    {
    }
}
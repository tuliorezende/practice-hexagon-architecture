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

    public List<ClassMaterialEntry> Materials { get; set; }

    public Course()
    {
    }
}
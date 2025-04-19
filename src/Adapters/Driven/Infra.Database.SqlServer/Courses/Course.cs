using Domain.Shared;

namespace Infra.Database.SqlServer.Courses;

public class Course
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public string Name { get; private set; }

    public string Description { get; private set; }

    public Discipline Discipline { get; private set; }

    public DateTimeOffset StartDate { get; private set; }

    public DateTimeOffset EndDate { get; private set; }

    public string? TeacherId { get; private set; }

    public Teacher Teacher { get; set; }

    public List<ClassMaterialEntry> Materials { get; private set; }
}
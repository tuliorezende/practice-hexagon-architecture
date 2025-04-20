using Domain.Shared;

namespace Infra.Database.SqlServer.Courses.Entities;

public class Teacher
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public string Name { get; private set; }

    public Discipline Discipline { get; private set; }

    public List<Course> Courses { get; private set; }
}
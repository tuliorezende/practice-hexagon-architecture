namespace Infra.Database.SqlServer.Courses.Entities;

public class ClassMaterialEntry
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Url { get; private set; }

    public List<Course> Courses { get; set; }
}
namespace Infra.Database.SqlServer.Courses.Entities;

public class ClassMaterialEntry
{
    public string Id { get; private set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Url { get; set; }

    public List<Course> Courses { get; set; }

    public ClassMaterialEntry()
    {
    }
}
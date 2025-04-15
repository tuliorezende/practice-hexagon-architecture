namespace Domain.Entities.Courses;

public class ClassMaterial
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Url { get; private set; }

    public ClassMaterial(string name, string description, string url)
    {
        this.Name = name;
        this.Description = description;
        this.Url = url;
    }
}
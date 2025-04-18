using System.Text.Json.Serialization;
using Domain.Courses.Entities;

namespace Domain.Courses.Dtos;

public class ClassMaterialEntryDto
{
    public string? Id { get; private set; } = Guid.NewGuid().ToString();

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Url { get; private set; }

    [JsonIgnore] public List<Course>? Courses { get; set; }

    [JsonConstructor]
    public ClassMaterialEntryDto(string name, string description, string url)
    {
        this.Name = name;
        this.Description = description;
        this.Url = url;
    }

    public ClassMaterialEntryDto(ClassMaterialEntry entry)
    {
        this.Id = entry.Id;
        this.Name = entry.Name;
        this.Description = entry.Description;
        this.Url = entry.Url;
    }
}
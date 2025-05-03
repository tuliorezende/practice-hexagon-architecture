using Domain.Courses.Dtos;

namespace Domain.Courses.Entities;

public class ClassMaterialEntry
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Url { get; private set; }

    public List<Course> Courses { get; set; }

    public ClassMaterialEntry(string name, string description, string url)
    {
        this.Name = name;
        this.Description = description;
        this.Url = url;
    }

    public ClassMaterialEntry(ClassMaterialEntryDto entry)
    {
        this.Id = entry.Id;
        this.Name = entry.Name;
        this.Description = entry.Description;
        this.Url = entry.Url;
    }

    public ClassMaterialEntry()
    {
    }
    
    public static ClassMaterialEntry Load(string id, string name, string description, string url)
    {
        return new ClassMaterialEntry
        {
            Id = id,
            Name = name,
            Description = description,
            Url = url,
        };
    }
    
    // public static ClassMaterialEntry Load(string id,
    //     string name,
    //     string description,
    //     Discipline discipline,
    //     DateTimeOffset startDate,
    //     DateTimeOffset endDate,
    //     string? teacherId = null,
    //     List<ClassMaterialEntry>? materials = null)
    // {
    //     return new Course
    //     {
    //         Id = id,
    //         Name = name,
    //         Description = description,
    //         Discipline = discipline,
    //         StartDate = startDate,
    //         EndDate = endDate,
    //         TeacherId = teacherId,
    //         Materials = materials
    //     };
    // }
}
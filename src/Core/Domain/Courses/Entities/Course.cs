using Domain.ValueObjects;

namespace Domain.Courses.Entities;

public class Course
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public string Name { get; set; }

    public string Description { get; set; }

    public Discipline Discipline { get; set; }

    public string Year { get; private set; }

    public string? TeacherId { get; private set; }

    public Teacher Teacher { get; set; }

    private List<ClassMaterial> Materials { get; set; }

    public Course(string teacherId, string name, string description, Discipline discipline, string year)
    {
        this.Name = name;
        this.Description = description;
        this.Discipline = discipline;
        this.Year = year;

        if (!string.IsNullOrEmpty(teacherId))
            this.TeacherId = teacherId;

        Materials = new List<ClassMaterial>();
    }

    public void AddMaterial(ClassMaterial classMaterial)
    {
        if (!this.Materials.Any(material => material.Id.Equals(classMaterial.Id)))
            this.Materials.Add(classMaterial);
    }
}
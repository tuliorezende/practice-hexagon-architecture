using Domain.Courses.Dtos;
using Domain.Shared;

namespace Domain.Courses.Entities;

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

    public Course(string teacherId, string name, string description, Discipline discipline, string year,
        DateTimeOffset startDate, DateTimeOffset endDate)
    {
        this.Name = name;
        this.Description = description;
        this.Discipline = discipline;
        this.StartDate = startDate;
        this.EndDate = endDate;

        if (!string.IsNullOrEmpty(teacherId))
            this.TeacherId = teacherId;

        Materials = new List<ClassMaterialEntry>();
    }

    public Course(CourseDto courseDto)
    {
        this.Name = courseDto.Name;
        this.Description = courseDto.Description;
        this.Discipline = courseDto.Discipline;
        this.StartDate = courseDto.StartDate;
        this.EndDate = courseDto.EndDate;

        if (courseDto.TeacherId != null)
            this.TeacherId = courseDto.TeacherId;

        this.Materials = new List<ClassMaterialEntry>();
    }

    private Course()
    {
    }

    public Course DeepClone(string courseId, Course course)
    {
        return new Course
        {
            Id = courseId,
            Name = course.Name,
            Description = course.Description,
            Discipline = course.Discipline,
            StartDate = course.StartDate,
            EndDate = course.EndDate,
            TeacherId = course.TeacherId,
            Materials = course.Materials
        };
    }

    public void AddMaterial(ClassMaterialEntry classMaterialEntry)
    {
        if (!this.Materials.Any(material => material.Id.Equals(classMaterialEntry.Id)))
            this.Materials.Add(classMaterialEntry);
    }
}
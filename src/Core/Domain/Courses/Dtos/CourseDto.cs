using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Courses.Entities;
using Domain.Shared;

namespace Domain.Courses.Dtos;

public class CourseDto
{
    public string? Id { get; set; }

    [Required] public string Name { get; private set; }

    [Required] public string Description { get; private set; }

    [Required] public Discipline Discipline { get; private set; }

    [Required] public DateTimeOffset StartDate { get; private set; }

    [Required] public DateTimeOffset EndDate { get; private set; }

    public string? TeacherId { get; private set; }

    [JsonConstructor]
    public CourseDto(string name, string description, Discipline discipline, DateTimeOffset startDate,
        DateTimeOffset endDate, string? teacherId)
    {
        this.Name = name;
        this.Description = description;
        this.Discipline = discipline;
        this.StartDate = startDate;
        this.EndDate = endDate;

        if (!string.IsNullOrEmpty(teacherId))
            this.TeacherId = teacherId;
    }

    public CourseDto(Course course)
    {
        this.Id = course.Id;
        this.Name = course.Name;
        this.Description = course.Description;
        this.Discipline = course.Discipline;
        this.StartDate = course.StartDate;
        this.EndDate = course.EndDate;
        this.TeacherId = course.TeacherId;
    }
}
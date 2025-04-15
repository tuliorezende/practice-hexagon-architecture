using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Entities.Courses;
using Domain.ValueObjects;

namespace Domain.Dto;

public class TeacherDto
{
    public string? Id { get; private set; }

    [Required] public string Name { get; private set; }

    [Required] public Discipline Discipline { get; private set; }

    [JsonConstructor]
    public TeacherDto(string name, Discipline discipline)
    {
        this.Name = name;
        this.Discipline = discipline;
    }

    public TeacherDto(Teacher teacher)
    {
        this.Id = teacher.Id;
        this.Name = teacher.Name;
        this.Discipline = teacher.Discipline;
    }
}
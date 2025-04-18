using System.Text.Json.Serialization;
using Domain.Shared;
using Domain.Students.Entities;

namespace Domain.Students.Dtos;

public class AcademicalHistoryEntryDto
{
    public string? Id { get; private set; } = Guid.NewGuid().ToString();

    public int Year { get; private set; }

    public Discipline Discipline { get; private set; }

    public double Score { get; private set; }

    [JsonIgnore] public string? StudentId { get; private set; }

    [JsonIgnore] public Student? Student { get; private set; }

    [JsonConstructor]
    public AcademicalHistoryEntryDto(string studentId, int year, Discipline discipline, double score)
    {
        StudentId = studentId;
        Year = year;
        Discipline = discipline;
        Score = score;
    }

    public AcademicalHistoryEntryDto(AcademicalHistoryEntry academicalHistoryEntry)
    {
        this.Id = academicalHistoryEntry.Id;
        this.Year = academicalHistoryEntry.Year;
        this.Discipline = academicalHistoryEntry.Discipline;
        this.Score = academicalHistoryEntry.Score;
        this.StudentId = academicalHistoryEntry.StudentId;
    }
}
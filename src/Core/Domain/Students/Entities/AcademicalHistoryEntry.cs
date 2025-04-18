using System.Text.Json.Serialization;
using Domain.Shared;
using Domain.Students.Dtos;

namespace Domain.Students.Entities;

public class AcademicalHistoryEntry
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public int Year { get; private set; }

    public Discipline Discipline { get; private set; }

    public double Score { get; private set; }

    public string StudentId { get; private set; }

    public Student? Student { get; private set; }

    public AcademicalHistoryEntry(string studentId, int year, Discipline discipline, double score)
    {
        this.Year = year;
        this.Discipline = discipline;
        this.Score = score;
        this.StudentId = studentId;
    }

    public AcademicalHistoryEntry(string studentId, AcademicalHistoryEntryDto academicalHistoryEntryDto)
    {
        this.Year = academicalHistoryEntryDto.Year;
        this.Discipline = academicalHistoryEntryDto.Discipline;
        this.Score = academicalHistoryEntryDto.Score;
        this.StudentId = studentId;
    }
}
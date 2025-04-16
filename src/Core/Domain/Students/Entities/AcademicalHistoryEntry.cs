using Domain.Students.Dtos;
using Domain.ValueObjects;

namespace Domain.Students.Entities;

public class AcademicalHistoryEntry
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public int Year { get; private set; }

    public Discipline Discipline { get; private set; }

    public double Score { get; private set; }

    public string StudentId { get; private set; }

    public Student Student { get; private set; }

    public AcademicalHistoryEntry(string studentId, int year, Discipline discipline, double score)
    {
        StudentId = studentId;
        Year = year;
        Discipline = discipline;
        Score = score;
    }
}
using Domain.ValueObjects;

namespace Domain.Students.Entities;

public class AcademicalHistory
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string StudentId { get; private set; }
    public int Year { get; private set; }
    public Discipline Discipline { get; private set; }
    public double Score { get; private set; }

    public AcademicalHistory(string studentId, int year, Discipline discipline, double score)
    {
        StudentId = studentId;
        Year = year;
        Discipline = discipline;
        Score = score;
    }
}
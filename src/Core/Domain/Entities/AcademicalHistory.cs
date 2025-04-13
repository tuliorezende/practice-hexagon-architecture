using Domain.ValueObjects;

namespace Domain.Entities;

public class AcademicalHistory
{
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
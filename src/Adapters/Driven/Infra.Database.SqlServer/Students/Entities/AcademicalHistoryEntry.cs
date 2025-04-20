using Domain.Shared;

namespace Infra.Database.SqlServer.Students.Entities;

public class AcademicalHistoryEntry
{
    public string Id { get; set; }

    public int Year { get; set; }

    public Discipline Discipline { get; set; }

    public double Score { get; set; }

    public string StudentId { get; set; }

    public Student? Student { get; set; }
}
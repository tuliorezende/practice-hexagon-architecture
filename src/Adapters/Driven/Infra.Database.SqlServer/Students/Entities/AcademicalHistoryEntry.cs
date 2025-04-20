using Domain.Shared;

namespace Infra.Database.SqlServer.Students.Entities;

public class AcademicalHistoryEntry
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public int Year { get; private set; }

    public Discipline Discipline { get; private set; }

    public double Score { get; private set; }

    public string StudentId { get; private set; }

    public Student? Student { get; private set; }
}
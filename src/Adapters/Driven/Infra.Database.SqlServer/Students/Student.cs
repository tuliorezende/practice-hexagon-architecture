using Domain.Students.ValueObjects;

namespace Infra.Database.SqlServer.Students;

public class Student
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string Name { get; private set; }
    public Address Address { get; private set; }

    public Telephone Telephone { get; private set; }

    public string Email { get; private set; }

    public PersonalDocument PersonalDocument { get; private set; }

    public List<AcademicalHistoryEntry> AcademicalHistory { get; private set; }
}
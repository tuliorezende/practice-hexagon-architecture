using Domain.Students.ValueObjects;

namespace Infra.Database.SqlServer.Students.Entities;

public class Student
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string Name { get; private set; }
    public Address Address { get; private set; }
    public Telephone Telephone { get; private set; }
    public string Email { get; private set; }
    public PersonalDocument PersonalDocument { get; private set; }

    public List<AcademicalHistoryEntry>? AcademicalHistory { get; private set; }

    public void Update(string studentId, Domain.Students.Entities.Student student)
    {
        this.Id = studentId;
        this.Name = student.Name;
        this.Address = student.Address;
        this.Telephone = student.Telephone;
        this.Email = student.Email;
        this.PersonalDocument = student.PersonalDocument;
    }

    public Student(string id, string name, Address address, Telephone telephone, string email,
        PersonalDocument personalDocument)
    {
        this.Id = id;
        this.Name = name;
        this.Address = address;
        this.Telephone = telephone;
        this.Email = email;
        this.PersonalDocument = personalDocument;
    }

    public Student()
    {
    }
}
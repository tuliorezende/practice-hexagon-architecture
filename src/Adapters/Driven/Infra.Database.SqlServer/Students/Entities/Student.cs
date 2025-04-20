using Domain.Students.ValueObjects;

namespace Infra.Database.SqlServer.Students.Entities;

public class Student
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
    public Telephone Telephone { get; set; }
    public string Email { get; set; }
    public PersonalDocument PersonalDocument { get; set; }

    public List<AcademicalHistoryEntry>? AcademicalHistory { get; set; }

    public void Update(string studentId, Domain.Students.Entities.Student student)
    {
        this.Id = studentId;
        this.Name = student.Name;
        this.Address = student.Address;
        this.Telephone = student.Telephone;
        this.Email = student.Email;
        this.PersonalDocument = student.PersonalDocument;
    }
    
    public Student()
    {
    }
}
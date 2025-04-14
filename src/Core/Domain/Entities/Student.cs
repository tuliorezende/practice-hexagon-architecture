using Domain.Dto;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Student
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string Name { get; private set; }
    public Address Address { get; private set; }
    
    public Telephone Telephone { get; private set; }
    
    public string Email { get; private set; }
    
    public PersonalDocument PersonalDocument { get; private set; }

    public List<AcademicalHistory> AcademicalHistory { get; private set; }

    public Student(string name, Address address, PersonalDocument personalDocument, Telephone telephone, string email)
    {
        this.Name = name;
        this.Address = address;
        this.PersonalDocument = personalDocument;
        this.Telephone = telephone;
        this.Email = email;
        this.AcademicalHistory = new List<AcademicalHistory>();
    }

    public Student(StudentDto studentDto)
    {

        if (!string.IsNullOrEmpty(studentDto.Id))
            this.Id = studentDto.Id;

        this.Name = studentDto.Name;
        this.Address = studentDto.Address;
        this.PersonalDocument = studentDto.PersonalDocument;
        this.Telephone = studentDto.Telephone;
        this.Email = studentDto.Email;
        this.AcademicalHistory = new List<AcademicalHistory>();
    }

    public bool AddAcademicalHistory(AcademicalHistory academicalHistory)
    {
        var historicalExists = this.AcademicalHistory.Any(a =>
            a.Discipline == academicalHistory.Discipline
            && a.Year == academicalHistory.Year
            && a.StudentId == this.Id);

        if (historicalExists)
            return false;

        this.AcademicalHistory.Add(academicalHistory);
        return true;
    }
}
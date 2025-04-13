using Domain.Dto;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Student
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string Name { get; private set; }
    public Address Address { get; private set; }
    public PersonalDocument PersonalDocument { get; private set; }

    private List<AcademicalHistory> AcademicalHistory { get; set; }

    public Student(string name, Address address, PersonalDocument personalDocument)
    {
        this.Name = name;
        this.Address = address;
        this.PersonalDocument = personalDocument;
        this.AcademicalHistory = new List<AcademicalHistory>();
    }

    public Student(StudentDto studentDto)
    {
        if (!string.IsNullOrEmpty(studentDto.Id))
            this.Id = studentDto.Id;

        this.Name = studentDto.Name;
        this.Address = studentDto.Address;
        this.PersonalDocument = studentDto.PersonalDocument;
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
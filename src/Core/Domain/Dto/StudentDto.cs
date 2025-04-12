using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Dto;

public class StudentDto
{
    public string? Id { get; set; }
    [Required] public string Name { get; private set; }
    [Required] public Address Address { get; private set; }
    [Required] public PersonalDocument PersonalDocument { get; private set; }

    [JsonConstructor]
    public StudentDto(string name, Address address, PersonalDocument personalDocument)
    {
        this.Name = name;
        this.Address = address;
        this.PersonalDocument = personalDocument;
    }

    public StudentDto(Student student)
    {
        this.Id = student.Id;
        this.Name = student.Name;
        this.Address = student.Address;
        this.PersonalDocument = student.PersonalDocument;
    }
}
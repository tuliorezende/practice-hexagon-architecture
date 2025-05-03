using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Students.Entities;
using Domain.Students.ValueObjects;

namespace Domain.Students.Dtos;

public class StudentDto
{
    public string? Id { get; set; }
    [Required] public string Name { get; private set; }
    [Required] public Address Address { get; private set; }
    [Required] public PersonalDocument PersonalDocument { get; private set; }

    [Required] public Telephone Telephone { get; private set; }

    [Required] public string Email { get; private set; }

    [JsonConstructor]
    public StudentDto(string name, Address address, PersonalDocument personalDocument, Telephone telephone,
        string email)
    {
        this.Name = name;
        this.Address = address;
        this.PersonalDocument = personalDocument;
        this.Telephone = telephone;
        this.Email = email;
    }

    public StudentDto(Student student)
    {
        this.Id = student.Id;
        this.Name = student.Name;
        this.Address = student.Address;
        this.PersonalDocument = student.PersonalDocument;
        this.Telephone = student.Telephone;
        this.Email = student.Email;
    }
}
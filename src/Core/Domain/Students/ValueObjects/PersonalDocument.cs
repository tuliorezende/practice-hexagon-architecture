using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Students.ValueObjects;

[ComplexType]
public class PersonalDocument
{
    public DocumentType DocumentType { get; private set; }
    public string DocumentNumber { get; private set; }

    public PersonalDocument(DocumentType documentType, string documentNumber)
    {
        this.DocumentType = documentType;
        this.DocumentNumber = documentNumber;
    }
}
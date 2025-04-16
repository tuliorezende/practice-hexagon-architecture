namespace Domain.Students.ValueObjects;

public class Telephone
{
    public string InternationalPrefix { get; private set; }

    public string NationalPrefix { get; private set; }

    public string Number { get; private set; }

    public Telephone(string internationalPrefix, string nationalPrefix, string number)
    {
        InternationalPrefix = internationalPrefix;
        NationalPrefix = nationalPrefix;
        Number = number;
    }
}
using GymGestor.Core.ValueObjects;

namespace GymGestor.Core.Entities;
public class Member : BaseEntity
{
    public Member(string fullName, DateTime dateOfBirth, Gender gender, CPF cpf, Email email, string phone, 
        string photoUrl, ICollection<HealthRecord> healthRecords, ICollection<Contract> contracts)
    {
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        CPF = cpf;
        Email = email;
        Phone = phone;
        PhotoUrl = photoUrl;
        HealthRecords = healthRecords;
        Contracts = contracts;
    }

    public string FullName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public CPF CPF { get; private set; }
    public Email Email { get; private set; }
    public string Phone { get; private set; }
    public string PhotoUrl { get; private set; }

    public ICollection<HealthRecord> HealthRecords { get; set; }
    public ICollection<Contract> Contracts { get; set; }
}

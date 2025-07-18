﻿using GymGestor.Core.ValueObjects;

namespace GymGestor.Core.Entities;
public class Member : BaseEntity
{
    public string FullName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public CPF CPF { get; private set; }
    public Email Email { get; private set; }
    public string Phone { get; private set; }
    public Address Address { get; private set; }
    public string PhotoUrl { get; private set; }

    public ICollection<HealthRecord> HealthRecords { get; set; }
    public ICollection<Contract> Contracts { get; set; }

    public Member(string fullName, DateTime dateOfBirth, Gender gender, CPF cpf, Email email, string phone,
    Address address, string photoUrl, ICollection<HealthRecord> healthRecords, ICollection<Contract> contracts)
    {
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        CPF = cpf;
        Email = email;
        Phone = phone;
        Address = address;
        PhotoUrl = photoUrl;
        HealthRecords = healthRecords ?? [];
        Contracts = contracts ?? [];
    }

    public Member() { } // EF

    public void Update(Email? email, string? phone, Address? address, string? photoUrl, ICollection<HealthRecord>? healthRecords)
    {
        if (email != null)
            Email = email;

        if (!string.IsNullOrWhiteSpace(phone))
            Phone = phone;

        if (address != null)
            Address = address;

        if (!string.IsNullOrWhiteSpace(photoUrl))
            PhotoUrl = photoUrl;

        if (healthRecords != null)
            HealthRecords = healthRecords;

        SetUpdatedAt();
    }
}

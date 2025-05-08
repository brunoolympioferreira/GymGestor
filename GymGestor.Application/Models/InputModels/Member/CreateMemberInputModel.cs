using GymGestor.Application.Models.DTOs;
using GymGestor.Core.ValueObjects;

namespace GymGestor.Application.Models.InputModels.Member
{
    public class CreateMemberInputModel
    {
        public required string FullName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string Gender { get; set; }
        public required string CPF { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required AddressDTO Address { get; set; }
        public required string PhotoUrl { get; set; }

        public Core.Entities.Member ToEntity(Gender gender, CPF cpf, Email email, Address address) => new(
            fullName: FullName,
            dateOfBirth: DateOfBirth,
            gender: gender,
            cpf: cpf,
            email: email,
            phone: Phone,
            address: address,
            photoUrl: PhotoUrl,
            healthRecords: [],
            contracts: []
        );
    }
}

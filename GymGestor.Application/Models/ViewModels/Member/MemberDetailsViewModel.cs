using GymGestor.Application.Models.DTOs;
using GymGestor.Core.Entities;

namespace GymGestor.Application.Models.ViewModels.Member;
public class MemberDetailsViewModel
{
    public string? FullName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? CPF { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public AddressDTO? Address { get; set; }
    public string? PhotoUrl { get; set; }

    public ICollection<HealthRecordDTO>? HealthRecords { get; set; }
    public ICollection<ContractDTO>? Contracts { get; set; }

    public static MemberDetailsViewModel FromEntity(Core.Entities.Member member)
    {
        var result = new MemberDetailsViewModel
        {
            FullName = member.FullName,
            DateOfBirth = DateOnly.FromDateTime(member.DateOfBirth),
            Gender = member.Gender.ToString(),
            CPF = member.CPF.Value,
            Email = member.Email.Value,
            Phone = member.Phone,
            Address = member.Address != null ? new AddressDTO
            {
                Street = member.Address.Street,
                Number = member.Address.Number,
                City = member.Address.City,
                State = member.Address.State,
                ZipCode = member.Address.ZipCode
            } : null,
            PhotoUrl = member.PhotoUrl,
            HealthRecords = member.HealthRecords?.Select(hr => new HealthRecordDTO
            {
                MemberId = hr.MemberId,
                Condition = hr.Condition,
                Notes = hr.Notes,
                RecordDate = hr.RecordDate
            }).ToList(),
            Contracts = member.Contracts?.Select(c => new ContractDTO
            {
                MemberId = c.MemberId,
                PlanName = c.PlanName.ToString(),
                Price = c.Price,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                IsAutoRenew = c.IsAutoRenew
            }).ToList()
        };

        return result;
    }
}

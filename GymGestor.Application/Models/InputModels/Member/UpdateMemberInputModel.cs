using GymGestor.Application.Models.DTOs;

namespace GymGestor.Application.Models.InputModels.Member;
public class UpdateMemberInputModel
{
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public AddressDTO? Address { get; set; }
    public string? PhotoUrl { get; set; }
    public ICollection<HealthRecordDTO>? HealthRecords { get; set; }
}

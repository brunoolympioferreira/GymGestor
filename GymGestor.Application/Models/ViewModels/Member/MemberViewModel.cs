namespace GymGestor.Application.Models.ViewModels.Member;
public class MemberViewModel
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? PhotoUrl { get; set; }

    public static MemberViewModel FromEntity(Core.Entities.Member member)
    {
        return new MemberViewModel
        {
            Id = member.Id,
            FullName = member.FullName,
            Email = member.Email.Value,
            Phone = member.Phone,
            PhotoUrl = member.PhotoUrl,
        };
    }
}

namespace GymGestor.Application.Models.DTOs;
public class HealthRecordDTO
{
    public Guid MemberId { get; set; }
    public string? Condition { get; set; }
    public string? Notes { get; set; }
    public DateTime RecordDate { get; set; }
}

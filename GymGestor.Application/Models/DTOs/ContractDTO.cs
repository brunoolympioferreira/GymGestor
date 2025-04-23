namespace GymGestor.Application.Models.DTOs;
public class ContractDTO
{
    public Guid MemberId { get; set; }
    public string? PlanName { get; set; }
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsAutoRenew { get; set; }
}

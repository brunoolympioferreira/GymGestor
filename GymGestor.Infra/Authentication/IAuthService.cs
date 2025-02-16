using GymGestor.Core.Entities;

namespace GymGestor.Infra.Authentication;
public interface IAuthService
{
    string GenerateJwtToken(User user);
    string ComputeSha256Hash(string password);
}

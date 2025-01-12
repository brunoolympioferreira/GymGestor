using GymGestor.Core.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GymGestor.Infra.Authentication;
public class AuthService : IAuthService
{
    public string ComputeSha256Hash(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        StringBuilder builder = new();

        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }

        return builder.ToString();
    }

    public string GenerateJwtToken(User user)
    {
        var issuer = Environment.GetEnvironmentVariable("GymGestor_Issuer");
        var audience = Environment.GetEnvironmentVariable("GymGestor_Audience");
        var key = Environment.GetEnvironmentVariable("GymGestor_Key");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims =
        [
            new("username", user.Username),
            new("user_id", user.Id.ToString()),
            new("role", user.Role.ToString())
        ];

        var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: credentials,
                claims: claims);

        var tokenHandler = new JwtSecurityTokenHandler();

        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }
}

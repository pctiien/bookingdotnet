using System.Security.Claims;
using bookingdotcom.Models;

namespace bookingdotcom.Services
{
    public interface ITokenService
    {
        string? GenerateToken(User user);
        ClaimsPrincipal? DecodeToken(string jwtToken);
        bool ValidateJwtToken(string jwtToken,string role,out int? userId);
    }
}
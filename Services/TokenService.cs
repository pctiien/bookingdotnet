using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using bookingdotcom.Models;
using Microsoft.IdentityModel.Tokens;

namespace bookingdotcom.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _Config;
        public TokenService(IConfiguration Config)
        {
            _Config = Config;
        }

        public ClaimsPrincipal? DecodeToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var secretKey = _Config.GetSection("AppSettings:SecretKey").Value;
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey??""));
                var tokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                };
                var claims =tokenHandler.ValidateToken(jwtToken,tokenValidationParameters,out _);
                return claims;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public string? GenerateToken(User user)
        {
            var claims = new Claim[]{
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,"User")
            };
            var secretKey = _Config.GetSection("AppSettings:SecretKey").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey??""));
            var signingCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;

        }

        public bool ValidateJwtToken(string jwtToken, string role,out int? userId)
        {
            userId =null;
            var claims = DecodeToken(jwtToken);
            if(claims!=null)
            {
                // Time check 
                var exp = claims.FindFirst("exp");
                if(exp!=null&&long.TryParse(exp.Value,out long expUnixTimestamp))
                {
                    var expDateTime = DateTimeOffset.FromUnixTimeSeconds(expUnixTimestamp).UtcDateTime;
                    if(DateTime.Now>expDateTime) return false;
                }
                var nameIden =claims.FindFirst(ClaimTypes.NameIdentifier);
                if(nameIden!=null)
                {
                    userId =int.Parse(nameIden.Value);
                }
                return true;

            }else return false;
        }
    }
}
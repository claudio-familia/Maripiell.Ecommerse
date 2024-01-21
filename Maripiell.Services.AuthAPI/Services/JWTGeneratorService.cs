using Maripiell.Common.Common.Domain.Common;
using Maripiell.Services.AuthAPI.Domain.Common;
using Maripiell.Services.AuthAPI.Domain.Models;
using Maripiell.Services.AuthAPI.Services.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Maripiell.Services.AuthAPI.Services
{
    public class JWTGeneratorService : IJWTGeneratorService
    {
        private readonly AuthSettings _authSettings;

        public JWTGeneratorService(IOptions<AuthSettings> authSettings)
        {
            _authSettings = authSettings.Value;
        }

        public string GenerateToken(User user)
        {
            try
            {
                List<Claim> claims = new List<Claim>()
                {
                     new Claim(ClaimTypes.Sid, user.Id.ToString()),
                     new Claim(ClaimTypes.Name, user.UserName),
                     new Claim(ClaimTypes.Email, user.Email),
                     new Claim(ClaimTypes.Role, "")
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                var expires = DateTime.Now.AddDays(7);

                var token = new JwtSecurityToken(
                    issuer: _authSettings.Issuer,
                    audience: _authSettings.Audience,
                    claims,
                    expires: expires,
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }catch (Exception ex)
            {
                throw new CustomError(ex.Message);
            }
        }
    }
}

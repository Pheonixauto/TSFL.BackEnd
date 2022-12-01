using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WinWin.Domain.Entity.User;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WinWin.Service.AuthenticationService
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateToken(Users users)
        {

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString(), ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Iss,_configuration["TokenBear:Issuer"],ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToString(), ClaimValueTypes.Integer64,_configuration["TokenBear:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Aud, "WinWin.Prsetation.Api", ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Exp, DateTime.Now.AddHours(3).ToString("yyyy/MM/dd hh:mm:ss"), ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
                //new Claim(ClaimTypes.NameIdentifier, users.Id.ToString()!, ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
                new Claim(ClaimTypes.Name, users.DisplayName!, ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
                new Claim("UserName", users.UserName!, ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenBear:SignatureKey"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenInfor = new JwtSecurityToken
            (
                issuer: _configuration["TokenBear:Issuer"],
                audience: _configuration["TokenBear:Audience"],
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(3),
                credential

                );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenInfor);

            return token;

        }
    }
}

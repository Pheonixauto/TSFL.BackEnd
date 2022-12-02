using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WinWin.Domain.Entity.User;
using WinWin.Service.IService.IUserServices;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WinWin.Service.AuthenticationService
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public TokenHandler(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }
        public async Task<(string, DateTime)> CreateToken(Users users)
        {
            var expiredDateToken = DateTime.Now.AddMinutes(15);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString(), ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Iss,_configuration["TokenBear:Issuer"],ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToString(), ClaimValueTypes.Integer64,_configuration["TokenBear:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Aud, "WinWin.Prsetation.Api", ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Exp,expiredDateToken.ToString("yyyy/MM/dd hh:mm:ss") , ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
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
                expires: expiredDateToken,
                credential

                );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenInfor);

            return await Task.FromResult((token, expiredDateToken));

        }

        public async Task<(string, DateTime)> CreateRefreshToken(Users users)
        {
            var expiredDateToken = DateTime.Now.AddMinutes(30);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString(), ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Iss,_configuration["TokenBear:Issuer"],ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToString(), ClaimValueTypes.DateTime,_configuration["TokenBear:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Aud, "WinWin.Prsetation.Api", ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Exp,expiredDateToken.ToString("yyyy/MM/dd hh:mm:ss"), ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),
                new Claim(ClaimTypes.SerialNumber, Guid.NewGuid().ToString(), ClaimValueTypes.String,_configuration["TokenBear:Issuer"]),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenBear:SignatureKey"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenInfor = new JwtSecurityToken
            (
                issuer: _configuration["TokenBear:Issuer"],
                audience: _configuration["TokenBear:Audience"],
                claims: claims,
                notBefore: DateTime.Now,
                expires: expiredDateToken,
                credential

                );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenInfor);

            return await Task.FromResult((token, expiredDateToken));

        }

        public async Task ValidateToken(TokenValidatedContext context)
        {
            var claims = context.Principal!.Claims.ToList();
            if (claims.Count == 0)
            {
                context.Fail("This token has no information");
                return;
            }

            var identity = context.Principal.Identity as ClaimsIdentity;
            if (identity!.FindFirst("UserName") == null)
            {
                string userName = identity.FindFirst("UserName")!.Value;
                var user = await _userService.FindByUserName(userName);
                if (user == null)
                {
                    context.Fail("This token is invalid User");
                    return;
                }
            }

            if (identity!.FindFirst(JwtRegisteredClaimNames.Exp) == null)
            {
                var exp = identity.FindFirst(JwtRegisteredClaimNames.Exp)!.Value;
                long tic = long.Parse(exp);
                var date = DateTimeOffset.FromUnixTimeSeconds(tic).DateTime;
                var minutes = date.Subtract(DateTime.Now).TotalMinutes;
                if (minutes < 0)
                {
                    context.Fail("This token expri");
                    throw new Exception("This token expri");
                }

            }
        }
    }
}

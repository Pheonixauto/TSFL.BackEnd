using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WinWin.Api.Data;
using WinWin.Api.IRepositories;
using WinWin.Api.Models.Author;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WinWin.Api.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<WinwinUser> _userManager;
        private readonly SignInManager<WinwinUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<WinwinUser> userManager, SignInManager<WinwinUser> signInManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<string> SignInAsync(SignInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);
            if (!result.Succeeded)
            {
                return String.Empty;
            }
            var authClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Email, signInModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(10),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authenKey,SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel signUpModel)
        {
            var newUser = new WinwinUser
            {
                FirstName = signUpModel.FirstName,
                MiddleName = signUpModel.MiddleName,
                LastName = signUpModel.LastName,
                Email = signUpModel.Email,
                UserName = signUpModel.Email
            };
            return await _userManager.CreateAsync(newUser, signUpModel.Password);
        }
    }
}

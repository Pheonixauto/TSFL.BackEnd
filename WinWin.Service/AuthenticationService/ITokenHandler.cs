using Microsoft.AspNetCore.Authentication.JwtBearer;
using WinWin.Domain.Entity.User;

namespace WinWin.Service.AuthenticationService
{
    public interface ITokenHandler
    {
        Task<(string, DateTime)> CreateRefreshToken(Users users);
        Task<(string, DateTime)> CreateToken(Users users);
        Task ValidateToken( TokenValidatedContext tokenValidatedContext);
    }
}
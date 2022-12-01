using WinWin.Domain.Entity.User;

namespace WinWin.Service.AuthenticationService
{
    public interface ITokenHandler
    {
        Task<string> CreateToken(Users users);
    }
}
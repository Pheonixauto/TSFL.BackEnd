using Microsoft.AspNetCore.Identity;
using WinWin.Api.Models.Author;

namespace WinWin.Api.IRepositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        public Task<string> SignInAsync(SignInModel signInModel);
    }
}

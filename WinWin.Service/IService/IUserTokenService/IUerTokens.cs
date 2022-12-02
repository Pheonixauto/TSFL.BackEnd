using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinWin.Domain.Entity.Token;
using WinWin.Service.Service.UserTokenService;

namespace WinWin.Service.IService.IUserTokenService
{
    public interface IUerTokens
    {
        Task SaveToken(Tokens tokens);
    }
}

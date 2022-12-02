using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinWin.Domain.Entity.Token;
using WinWin.Persistence.IGenericRepositories;
using WinWin.Service.IService.IUserTokenService;

namespace WinWin.Service.Service.UserTokenService
{
    public class UserTokens : IUerTokens
    {
        private readonly IGenericRepository<Tokens> _genericRepository;

        public UserTokens(IGenericRepository<Tokens> genericRepository)
        {
           _genericRepository = genericRepository;
        }

        public async Task SaveToken(Tokens tokens)
        {
            await _genericRepository.Insert(tokens);
            await _genericRepository.CommitAsync();
        }
    }
}

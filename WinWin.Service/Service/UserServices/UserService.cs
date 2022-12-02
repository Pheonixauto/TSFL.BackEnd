using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinWin.Domain.Entity.User;
using WinWin.Persistence.IGenericRepositories;
using WinWin.Service.IService.IUserServices;

namespace WinWin.Service.Service.UserServices
{
    public class UserService : IUserService
    {
        IGenericRepository<Users> _genericRepository;
        public UserService(IGenericRepository<Users> genericRepository)
        {
            _genericRepository=genericRepository;
        }
        public async Task<Users?> CheckLogin(string userName, string password)
        {
            return await _genericRepository.GetSingleByConditionAsync(x => x.UserName!.Equals(userName) && x.PassWord!.Equals(password));
        }

        public  async Task<Users?> FindByUserName(string userName)
        {
            return await _genericRepository.GetSingleByConditionAsync(x => x.UserName == userName);
        }
    }
}

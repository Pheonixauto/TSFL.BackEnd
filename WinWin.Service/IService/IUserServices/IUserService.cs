using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinWin.Domain.Entity.User;

namespace WinWin.Service.IService.IUserServices
{
    public interface IUserService
    {
        Task<Users?> CheckLogin(string userName, string password);
    }
}

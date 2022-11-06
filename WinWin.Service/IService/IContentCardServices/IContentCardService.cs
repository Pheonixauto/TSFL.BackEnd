using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinWin.Service.IService.IContentCardServices
{
    public interface IContentCardService
    {
        Task<byte[]?> GetImage(string fileName);
    }
}

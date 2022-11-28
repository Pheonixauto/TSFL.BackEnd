using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinWin.Domain.Model;

namespace WinWin.Service.IService.IContentCardServices
{
    public interface IContentCardService
    {
        Task<CardContent> GetCardContent(string fileName);
        Task<byte[]?> GetCardContentTxt(string fileName);
        Task<byte[]?> GetImage(string fileName);
        Task<byte[]?> GetZipContent(string fileName);
    }
}

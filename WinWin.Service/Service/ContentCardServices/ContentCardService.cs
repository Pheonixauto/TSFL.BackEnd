
using Microsoft.Extensions.Configuration;
using WinWin.Service.IService.IContentCardServices;

namespace WinWin.Service.Service.ContentCardServices
{
    public class ContentCardService : IContentCardService
    {
        private readonly IConfiguration _configuration;

        public ContentCardService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<byte[]?> GetImage(string fileName)
        {        
                string path = _configuration.GetConnectionString("PathCardContent");

                var filePath = path + fileName + ".jpg";
                if (File.Exists(filePath))
                {
                    byte[] b = await File.ReadAllBytesAsync(filePath);
                    return b;
                }
                return null;                      
        }
        public async Task<string?> GetCardContent(string fileName)
        {
            string path = _configuration.GetConnectionString("PathCardContent");
            var filePath = path + fileName + ".txt";
            if (File.Exists(filePath))
            {
                var b = await File.ReadAllTextAsync(filePath);
                return b;
            }
            return null;
        }
    }
    
}


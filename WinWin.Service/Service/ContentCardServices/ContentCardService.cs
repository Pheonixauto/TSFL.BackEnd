
using Microsoft.Extensions.Configuration;
using WinWin.Domain.Model;
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

        public async Task<byte[]?> GetCardContentTxt(string fileName)
        {
            string path = _configuration.GetConnectionString("PathCardContent");

            var filePath = path + fileName + ".txt";
            if (File.Exists(filePath))
            {
                byte[] b = await File.ReadAllBytesAsync(filePath);
                return b;
            }
            return null;

        }

            public async Task<CardContent?> GetCardContent(string fileName)
        {
            CardContent cardContent = new CardContent();
            string path = _configuration.GetConnectionString("PathCardContent");
            var filePath = path + fileName + ".txt";
            if (File.Exists(filePath))
            {
                cardContent.Card_Content  = await File.ReadAllTextAsync(filePath);
                return cardContent;
            }
            return null;
        }

        public async Task<byte[]?> GetZipContent(string fileName)
        {
            string path = _configuration.GetConnectionString("PathCardContent");

            var filePath = path + fileName + ".zip";
            if (File.Exists(filePath))
            {
                byte[] b = await File.ReadAllBytesAsync(filePath);
                return b;
            }
            return null;
        }

        public async Task<byte[]?> GetVideo(string fileName)
        {
            string path = _configuration.GetConnectionString("PathCardContent");
            fileName = "Freedom\\6b036a05-203f-461c-f5bb-08dabfac97f0";

            var filePath = path + fileName + ".mp4";
            if (File.Exists(filePath))
            {
                byte[] b = await File.ReadAllBytesAsync(filePath);
                return b;
            }
            return null;
        }
    }
    
}


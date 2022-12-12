using Microsoft.AspNetCore.Mvc;
using WinWin.Service.IService.IContentCardServices;

namespace WinWin.Prsetation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentCardsController : ControllerBase
    {
        private readonly IContentCardService _contentCardService;

        public ContentCardsController(IContentCardService contentCardService)
        {

            _contentCardService = contentCardService;
        }

        [HttpGet]
        [Route("image")]
        public async Task<IActionResult> GetCardImage(string fileName)
        {
            try
            {
                var result = await _contentCardService.GetImage(fileName);
                if (result == null)
                {
                    return NoContent();
                }
                return File(result, "image/jpg");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("txt")]
        public async Task<IActionResult> GetCardImageTxt(string fileName)
        {
            try
            {
                var result = await _contentCardService.GetCardContentTxt(fileName);
                if (result == null)
                {
                    return NoContent();
                }
                return File(result, "text/txt");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("content-image")]
        public async Task<IActionResult> GetCardContent(string fileName)
        {
            try
            {
                var result = await _contentCardService.GetCardContent(fileName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("zip")]
        public async Task<IActionResult> GetZip(string fileName)
        {
            try
            {
                var result = await _contentCardService.GetZipContent(fileName);
                if (result == null)
                {
                    return NoContent();
                }
                return File(result, "application/zip");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("video")]
        public async Task<IActionResult> getVideo(string fileName)
        {
            try
            {
                var result = await _contentCardService.GetVideo(fileName);
                if (result == null)
                {
                    return NoContent();
                }
                return File(result, "video/mp4");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //[Route("video")]
        //public async Task getVideo()
        //{
        //    const string filePath = $"D:/MyProject/CardContent/Freedom/6b036a05-203f-461c-f5bb-08dabfac97f0.mp4";
        //    this.Response.StatusCode = 200;
        //    this.Response.Headers.Add(HeaderNames.ContentDisposition, $"attachment; filename=\"{Path.GetFileName(filePath)}\"");
        //    this.Response.Headers.Add(HeaderNames.ContentType, "application/octet-stream");
        //    var inputStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        //    var outputStream = this.Response.Body;
        //    const int bufferSize = 1 << 10;
        //    var buffer = new byte[bufferSize];
        //    while (true)
        //    {
        //        var bytesRead = await inputStream.ReadAsync(buffer, 0, bufferSize);
        //        if (bytesRead == 0) break;
        //        await outputStream.WriteAsync(buffer, 0, bytesRead);
        //    }
        //    await outputStream.FlushAsync();
        //}
    }
}

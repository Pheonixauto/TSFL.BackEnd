using Microsoft.AspNetCore.Mvc;
using WinWin.Service.IService.IContentCardServices;

namespace WinWin.Prsetation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentCardsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IContentCardService _contentCardService;

        public ContentCardsController(IConfiguration configuration, IContentCardService contentCardService)
        {
            _configuration = configuration;
            _contentCardService = contentCardService;
        }

        [HttpGet]
        [Route("Image")]
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
    }
}

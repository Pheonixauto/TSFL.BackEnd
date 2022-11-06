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
    }
}

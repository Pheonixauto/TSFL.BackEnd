using Microsoft.AspNetCore.Mvc;
using WinWin.Api.IRepositories;
using WinWin.Api.Models;

namespace WinWin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardsRepository _cardsRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public CardsController(ICardsRepository cardsRepository, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _cardsRepository = cardsRepository;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            try
            {
                var cards = await _cardsRepository.GetAllCardsAsync();
                return Ok(cards);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetCardById")]
        public  async Task<IActionResult> GetCardById(Guid id)
        {
            var card = await _cardsRepository.GetCardAsync(id);
            return (card != null) ? Ok(card) : NotFound();
        }

        [HttpGet]
        [Route("GetCardImage")]
        public async Task<IActionResult> GetCardImage(string fileName)
        {
            try
            {
                string path = _configuration.GetValue<string>("PathCardContent");

                var filePath = path + fileName + ".jpg";

                if (System.IO.File.Exists(filePath))
                {
                    byte[] b = await System.IO.File.ReadAllBytesAsync(filePath);
                    return File(b, "image/jpg");
                }
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
     
        }

        [HttpGet]
        [Route("GetCardContent")]
        public async Task<IActionResult> GetCardContent(string fileName)
        {
            try
            {
                string path = _configuration.GetValue<string>("PathCardContent");
                var filePath = path + fileName + ".txt";

                if (System.IO.File.Exists(filePath))
                {
                    var b = await System.IO.File.ReadAllTextAsync(filePath);
                    if (b != null)
                    {
                        return Ok(b);
                    }
                }
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddCard(CardModel model)
        {
            try
            {
                var result = await _cardsRepository.AddCardAsync(model);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }        
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCard(Guid id, [FromBody] CardModel model)
        {
            try
            {
               await _cardsRepository.UpdateCardAsync(id,model);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard([FromRoute]Guid id)
        {
            try
            {
                await _cardsRepository.DeleteCardAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}

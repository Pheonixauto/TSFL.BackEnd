using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        public CardsController(ICardsRepository cardsRepository, IWebHostEnvironment webHostEnvironment)
        {
            _cardsRepository = cardsRepository;
            _webHostEnvironment = webHostEnvironment;
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

        [HttpGet("{id}")]
        public  async Task<IActionResult> GetCardById(Guid id)
        {
            var card = await _cardsRepository.GetCardAsync(id);
            return (card != null) ? Ok(card) : NotFound();
        }


        [HttpGet("{fileName:alpha}")]
        public async Task<IActionResult> GetCardImage([FromRoute] string fileName)
        {
            try
            {
                //string path = _webHostEnvironment.WebRootPath + "\\";
                string path = "C:\\Users\\ATS\\OneDrive\\Máy tính\\New folder\\";
                //var filePath = path + fileName + ".png";
                var filePath = path + fileName + ".jpg";

                if (System.IO.File.Exists(filePath))
                {
                    byte[] b = await System.IO.File.ReadAllBytesAsync(filePath);
                    //return File(b, "image/png");
                    return File(b, "image/jpg");
                }
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
     
        }

        [HttpPost]
        //[Authorize]
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
        //[Authorize]
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

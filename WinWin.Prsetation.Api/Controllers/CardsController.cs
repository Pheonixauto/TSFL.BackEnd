using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinWin.Domain.Entities.Card;
using WinWin.Service.IService.ICardServices;

namespace WinWin.Prsetation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCardAsync()
        {
            var cards = await _cardService.GetAllCardsAsync();
            return Ok(cards);
        }

        [HttpGet]
        [Route("get-card-randoom")]
        public async Task<IActionResult> GetCardRandoom()
        {
            var cards = await _cardService.GetCardSRandoom();
            return Ok(cards);
        }

        [HttpGet]
        [Route("get-card-by-id")]
        public async Task<IActionResult> GetCardById(Guid id)
        {
            var result = await _cardService.GetCardById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] Cards cards)
        {
            try
            {
                await _cardService.AddCardAsync(cards);
                return Ok("success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateCard([FromBody] Cards cards)
        {
            try
            {
                _cardService.UpdateCard(cards);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
       
        }

    }
}

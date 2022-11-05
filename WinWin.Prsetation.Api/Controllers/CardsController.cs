using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinWin.Domain.Entities.Card;
using WinWin.Service.Service.ICardServices;

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
    }
}

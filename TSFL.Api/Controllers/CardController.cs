using Microsoft.AspNetCore.Mvc;
using System.Net;
using TSFL.Application.IRepository.ICardRepository;
using TSFL.Application.ViewModels.CardModel;
using TSFL.Domain.Entities;

namespace TSFL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardReadRepository _cardReadRepository;
        private readonly ICardWriteRepository _cardWriteRepository;

        //private readonly ICardService _cardService;

        public CardController(ICardReadRepository cardReadRepository
            , ICardWriteRepository cardWriteRepository)
        {
            _cardReadRepository = cardReadRepository;
            _cardWriteRepository = cardWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCard()
        {

            var cards = _cardReadRepository.GetAll(false);
            if (cards != null)
            {
                return Ok(cards);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardById([FromRoute] Guid id)
        {
            var card = await _cardReadRepository.GetByIdAsync(id, false);
            return (card == null) ?  NotFound() : Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> AddCards(VM_Create_Card vM_Create_Card)
        {
            if (ModelState.IsValid)
            {

            }
           await _cardWriteRepository.AddAsync(new Card()
            {
                Name = vM_Create_Card.Name,

            });
            await _cardWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCard(VM_Update_Card vM_Update_Card)
        {
            Card card = await _cardReadRepository.GetByIdAsync(vM_Update_Card.Id);
            card.Name = vM_Update_Card.Name;
            await _cardWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(Guid id)
        {
            var resultCheck = await _cardWriteRepository.RemoveAsync(id);
            await _cardWriteRepository.SaveAsync();
            return Ok(resultCheck);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSFL.Application.Abstractions;
using TSFL.Application.IRepository.ICardGroupCardsRepository;
using TSFL.Application.IRepository.ICardRepository;

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
        public async Task GetAllCard()
        {

            await _cardWriteRepository.AddRangeAsync(new()
            {
                new() { Id=Guid.NewGuid(), Name="love" },
                new() { Id=Guid.NewGuid(), Name="Name" },
            });
           var count = await _cardWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardById([FromRoute] Guid id)
        {
            var card = await _cardReadRepository.GetByIdAsync(id);
            return (card == null) ?  NotFound() : Ok(card);
        }
    }
}

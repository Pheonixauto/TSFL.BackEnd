using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WinWin.Api.Data;
using WinWin.Api.IRepositories;
using WinWin.Api.Models;

namespace WinWin.Api.Repositories
{
    public class CardsRepository : ICardsRepository
    {
        private readonly WinWinContext _context;
        private readonly IMapper _mapper;

        public CardsRepository(WinWinContext context, IMapper mapper)
        {
           _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddCardAsync(CardModel model)
        {
            var card = _mapper.Map<Card>(model);
            _context.Cards!.Add(card);
            return  await _context.SaveChangesAsync();
            
        }

        public async Task DeleteCardAsync(Guid id)
        {
            var card = _context.Cards!.SingleOrDefault(x => x.Id == id);
            if (card != null)
            {
               _context.Cards!.Remove(card);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CardModel>> GetAllCardsAsync()
        {
            var cards = await _context.Cards!.ToListAsync();
            return _mapper.Map<List<CardModel>>(cards);
        }

        public async Task<CardModel> GetCardAsync(Guid id)
        {
            var card = await _context.Cards!.FindAsync(id);
            return _mapper.Map<CardModel>(card);
        }

        public async Task UpdateCardAsync(Guid id, CardModel model)
        {
            if (id==model.Id)
            {
                var updateCard = _mapper.Map<Card>(model);
                _context.Cards!.Update(updateCard);
                await _context.SaveChangesAsync();
            }
        }
    }
}

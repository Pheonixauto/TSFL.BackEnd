using WinWin.Domain.Entities.Card;
using WinWin.Persistence.IGenericDapperRepositories;
using WinWin.Persistence.IGenericRepositories;
using WinWin.Service.Service.ICardServices;

namespace WinWin.Service.Service.CardServices
{
    public class CardService : ICardService
    {
        private readonly IGenericRepository<Cards> _genericRepository;
        private readonly IGenericDapperRepository _genericDapperRepository;

        public CardService(IGenericRepository<Cards> genericRepository, IGenericDapperRepository genericDapperRepository)
        {
            _genericRepository = genericRepository;
             _genericDapperRepository = genericDapperRepository;
        }
        public async Task<IEnumerable<Cards>> GetAllCardsAsync()
        {
            string query = $"Select * FROM Cards";
            //return await _genericRepository.GetAll();
            return await _genericDapperRepository.ExcuteSqlReturnList<Cards>(query);
               
        }

        public async Task AddCardAsync(Cards cards)
        {
           await _genericRepository.Insert(cards);
           await _genericRepository.Commit();
        }
    }
}

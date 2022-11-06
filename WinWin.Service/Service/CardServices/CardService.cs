using AutoMapper;
using WinWin.Domain.Entities.Card;
using WinWin.Domain.Model;
using WinWin.Persistence.IGenericDapperRepositories;
using WinWin.Persistence.IGenericRepositories;
using WinWin.Service.IService.ICardServices;

namespace WinWin.Service.Service.CardServices
{
    public class CardService : ICardService
    {
        private readonly IGenericRepository<Cards> _genericRepository;
        private readonly IGenericDapperRepository _genericDapperRepository;
        private readonly IMapper _mapper;

        public CardService(IGenericRepository<Cards> genericRepository, IGenericDapperRepository genericDapperRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
             _genericDapperRepository = genericDapperRepository;
           _mapper = mapper;
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
           await _genericRepository.CommitAsync();
        }

        public async Task<Cards?> GetCardById(Guid id)
        {
            var cardDTO =  _mapper.Map<CardDTO>(await _genericRepository.GetById(id));
            cardDTO.PathImage = cardDTO.Name + "\\" + cardDTO.Id;
            return cardDTO;
        }

        public  void UpdateCard(Cards cards)
        {        
             _genericRepository.Update(cards);
             _genericRepository.Commit();
        }
    }
}

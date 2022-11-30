using AutoMapper;
using Microsoft.Data.SqlClient;
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

        public async Task<IEnumerable<Cards>> GetAllCard()
        {
            return await _genericRepository.GetAll1($"SP_GetAllCard");
        }

        public async Task<IEnumerable<Cards>> GetCardSRandoom()
        {
            string query = $"SELECT TOP 1 Id,Name,Description FROM Cards\r\nORDER BY NEWID()";
            var cards = await _genericDapperRepository.ExcuteSqlReturnList<Cards>(query);
            var cardDTOs = _mapper.Map<IEnumerable<CardDTO>>(cards);
            foreach (var item in cardDTOs)
            {
                item.PathImage = item.Name + "\\" + item.Id;
            }
            return cardDTOs;
        }


        public async Task AddCardAsync(Cards cards)
        {
            await _genericRepository.Insert(cards);
            await _genericRepository.CommitAsync();
        }

        public async Task<Cards?> GetCardById(Guid id)
        {
            var cardDTO = _mapper.Map<CardDTO>(await _genericRepository.GetById(id));
            cardDTO.PathImage = cardDTO.Name + "\\" + cardDTO.Id;
            return cardDTO;
        }

        public IEnumerable<Cards> GetTest(Guid id)
        {
            var para = new SqlParameter[]
            {
                new SqlParameter{  ParameterName = "@Id",Value=id,}
            };
            return _genericRepository.GetTest($"SP_GET_CARD_BY_ID @Id", para);
        }


        public void UpdateCard(Cards cards)
        {
            _genericRepository.Update(cards);
            _genericRepository.Commit();
        }

        public void DeleteCard(Guid id)
        {
            _genericRepository.Delete(id);
            _genericRepository.Commit();
        }
    }
}

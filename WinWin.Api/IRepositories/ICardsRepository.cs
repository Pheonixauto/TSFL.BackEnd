using WinWin.Api.Data;
using WinWin.Api.Models;

namespace WinWin.Api.IRepositories
{
    public interface ICardsRepository
    {
        public Task<List<CardModel>> GetAllCardsAsync();
        public Task<CardModel> GetCardAsync(Guid id);
        public Task<int> AddCardAsync(CardModel model);
        public Task UpdateCardAsync(Guid id , CardModel model);
        public Task DeleteCardAsync(Guid id);
    }
}

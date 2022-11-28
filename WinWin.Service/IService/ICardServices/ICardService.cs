using WinWin.Domain.Entities.Card;

namespace WinWin.Service.IService.ICardServices
{
    public interface ICardService
    {
        Task AddCardAsync(Cards cards);
        Task<IEnumerable<Cards>> GetAllCardsAsync();
        Task<Cards?> GetCardById(Guid id);
        Task<IEnumerable<Cards>> GetCardSRandoom();
        void UpdateCard(Cards cards);
        void DeleteCard(Guid id);
        Cards GetTest(Guid id);
    }
}
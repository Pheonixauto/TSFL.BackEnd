using WinWin.Domain.Entities.Card;

namespace WinWin.Service.Service.ICardServices
{
    public interface ICardService
    {
        Task AddCardAsync(Cards cards);
        Task<IEnumerable<Cards>> GetAllCardsAsync();
    }
}
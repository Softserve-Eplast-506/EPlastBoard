using EPlastBoard.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EPlastBoard.BLL.Interfaces.Cards
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetAllCardsAsync();
        Task<IEnumerable<Card>> GetCardByColumnAsync(int id);
        Task<Card> GetCardByIdAsync(int id);
        Task UpdateCardAsync(IEnumerable<Card> card);
        Task<int> EditCardAsync(Card card);
        Task<int> DeleteCardAsync(int id);
        Task<Card> CreateCard(Card card);
        Task<IEnumerable<Card>> GetAllCardByColumnAsync(int columnId);
        Task<IEnumerable<Card>> GetCardsByBoardAsync(int columnId);
    }
}

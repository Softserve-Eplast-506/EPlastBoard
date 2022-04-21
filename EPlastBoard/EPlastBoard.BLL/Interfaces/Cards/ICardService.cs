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
        Task<Card> GetCardByIdAsync(int id);
        Task<int> EditCardAsync(Card card);
        void DeleteCardAsync(int id);
        Task<Card> CreateCard(Card card);

    }
}

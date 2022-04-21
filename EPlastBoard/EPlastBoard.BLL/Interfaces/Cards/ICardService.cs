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
        void EditCardAsync(Card card);
        void DeleteCardAsync(int id);
        void CreateCard(Card card);

    }
}

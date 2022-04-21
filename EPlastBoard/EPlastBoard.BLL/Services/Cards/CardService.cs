using EPlastBoard.BLL.Interfaces.Cards;
using EPlastBoard.DAL.Entities;
using EPlastBoard.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlastBoard.BLL.Services.Cards
{
    public class CardService: ICardService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public CardService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public void CreateCard(Card card)
        {
            _repoWrapper.Card.CreateAsync(card);
            _repoWrapper.SaveAsync();

        }

        public void DeleteCardAsync(int id)
        {
            var card = (_repoWrapper.Card.GetFirstOrDefaultAsync(x => x.Id == id)).Result;
            _repoWrapper.Card.Delete(card);
            _repoWrapper.SaveAsync();
        }

        public void EditCardAsync(Card card)
        {
            _repoWrapper.Card.Update(card);
            _repoWrapper.SaveAsync();
        }

        public Task<IEnumerable<Card>> GetAllCardsAsync()
        {
            return  _repoWrapper.Card.GetAllAsync();
        }

        public Task<Card> GetCardByIdAsync(int id)
        {
            return _repoWrapper.Card.GetFirstOrDefaultAsync(c => c.Id == id);
        }

        
    }
}

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

        public async Task<Card> CreateCard(Card card)
        {
            await  _repoWrapper.Card.CreateAsync(card);
            await  _repoWrapper.SaveAsync();
            return card;

        }

        public void DeleteCardAsync(int id)
        {
            var card = (_repoWrapper.Card.GetFirstOrDefaultAsync(x => x.Id == id)).Result;
            _repoWrapper.Card.Delete(card);
            _repoWrapper.SaveAsync();
        }

        public async Task<int> EditCardAsync(Card card)
        {
            _repoWrapper.Card.Update(card);
            await _repoWrapper.SaveAsync();

            return card.Id;
        }

        public Task<IEnumerable<Card>> GetAllCardsAsync()
        {
            return  _repoWrapper.Card.GetAllAsync();
        }

        public Task<Card> GetCardByIdAsync(int id)
        {
            return _repoWrapper.Card.GetFirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Card>> GetAllCardByColumnAsync(int columnId)
        {
            return await _repoWrapper.Card.GetAllAsync(c => c.Column.Id == columnId);
        }

        public async Task<IEnumerable<Card>> GetCardByColumnAsync(int id)
        {
            return await _repoWrapper.Card.GetAllAsync(x => x.ColumnId == id);
        }
    }
}

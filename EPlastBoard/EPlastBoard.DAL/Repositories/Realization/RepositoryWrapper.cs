using EPlastBoard.DAL.Repositories;
using EPlastBoard.DAL.Repositories.Interfaces;
using EPlastBoard.DAL.Repositories.Realization;

namespace EPlastBoard.DAL.Entities
{
    internal class RepositoryWrapper: IRepositoryWrapper
    {
        private readonly EPlastBoardDBContext? _dbContext;

        private IColumnRepository? _column;

        public IColumnRepository Column
        {
            get
            {
                if (_column == null)
                {
                    _column = new ColumnRepository(_dbContext);
                }
                return _column;
            }
        }

        private ICardRepository? _card;

        public ICardRepository Card
        {
            get
            {
                if (_card == null)
                {
                    _card = new CardRepository(_dbContext);
                }
                return _card;
            }
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

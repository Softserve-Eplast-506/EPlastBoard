using EPlastBoard.DAL.Repositories.Interfaces;

namespace EPlastBoard.DAL.Repositories.Realization
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly EPlastBoardDBContext _dbContext;
       
        private IColumnRepository _column;
        private IBoardRepository _board;

        public RepositoryWrapper(EPlastBoardDBContext dBContext)
        {
            _dbContext = dBContext;
        }
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

        public IBoardRepository Boards
        {
            get
            {
                if (_board == null)
                {
                    _board = new BoardRepository(_dbContext);
                }
                return _board;
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

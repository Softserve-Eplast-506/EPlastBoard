using EPlastBoard.DAL.Repositories.Interfaces;

namespace EPlastBoard.DAL.Repositories.Realization
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private readonly EPlastBoardDBContext _dbContext;

        private IColumnRepository _column;

        public RepositoryWrapper(EPlastBoardDBContext dbContext)
        {
            _dbContext = dbContext;
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

    }
}

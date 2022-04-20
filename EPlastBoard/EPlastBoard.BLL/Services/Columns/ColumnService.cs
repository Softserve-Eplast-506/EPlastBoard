using EPlastBoard.BLL.Interfaces.Columns;
using EPlastBoard.DAL.Repositories.Interfaces;

namespace EPlastBoard.BLL.Services.Columns
{
    public class ColumnService: IColumnService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public ColumnService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
    }
}

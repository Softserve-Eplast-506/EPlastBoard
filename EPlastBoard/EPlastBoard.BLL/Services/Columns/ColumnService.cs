using EPlastBoard.BLL.Interfaces.Columns;
using EPlastBoard.DAL.Entities;
using EPlastBoard.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EPlastBoard.BLL.Services.Columns
{
    public class ColumnService : IColumnService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public ColumnService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        public async Task<IEnumerable<Column>> GetAllColumnsByBoardAsync(int boardId)
        {
            return await _repoWrapper.Column.GetAllAsync(c => c.Board.Id == boardId);
        }
    }
}

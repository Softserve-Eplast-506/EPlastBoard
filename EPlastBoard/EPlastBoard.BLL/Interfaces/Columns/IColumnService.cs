using EPlastBoard.BLL.DTO;
using EPlastBoard.DAL.Entities;

namespace EPlastBoard.BLL.Interfaces.Columns
{
    public interface IColumnService
    {
        Task<IEnumerable<Column>> GetAllColumnsByBoardAsync(int boardId);
        Task<Column> GetColumnByIdAsync(int id);
        Task<int> EditColumnNameAsync(Column column);
        Task UpdateColumns(IEnumerable<Column> column);
        Task<Column> CreateColumnAsync(Column column);
        Task<int> DeleteColumnAsync(int id);
    }
}

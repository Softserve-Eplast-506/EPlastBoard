using EPlastBoard.DAL.Entities;

namespace EPlastBoard.BLL.Interfaces.Columns
{
    public interface IColumnService
    {
        Task<IEnumerable<Column>> GetAllColumnsByBoardAsync(int boardId);
        Task<Column> GetColumnByIdAsync(int id);
        Task<int> EditColumnNameAsync(Column column);
        /*Task<int> CreateColumnAsync(Column column);
        Task<Column> DeleteColumnAsync(int id);*/
    }
}

using EPlastBoard.DAL.Entities;

namespace EPlastBoard.BLL.Interfaces.Boards
{
    public interface IBoardService
    {
        Task<IEnumerable<Board>> GetBoardsListAsync();
        Task<Board> GetBoardByIdAsync(int id);
        Task<int> EditBoardNameAsync(Board board);
        Task<int> DeleteBoardByIdAsync(int id);
        Task<Board> AddNewBoardAsync(Board newBoard);
    }
}

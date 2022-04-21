using EPlastBoard.DAL.Entities;
using EPlastBoard.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

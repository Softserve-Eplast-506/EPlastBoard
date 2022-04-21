using EPlastBoard.BLL.Interfaces.Boards;
using EPlastBoard.DAL.Entities;
using EPlastBoard.DAL.Repositories.Interfaces;

namespace EPlastBoard.BLL.Services.Boards
{
    public class BoardService : IBoardService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public BoardService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<IEnumerable<Board>> GetBoardsListAsync()
        {
            return await _repoWrapper.Boards.GetAllAsync();
        }

        public async Task<Board> GetBoardByIdAsync(int id)
        {
            return await _repoWrapper.Boards.GetFirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> EditBoardNameAsync(Board board)
        {
            _repoWrapper.Boards.Attach(board);
            _repoWrapper.Boards.Update(board);
            await _repoWrapper.SaveAsync();

            return board.Id;
        }


    }
}

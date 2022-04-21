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

        public async Task AddNewBoardAsync(Board newBoard)
        {
            await _repoWrapper.Boards.CreateAsync(newBoard);
            // add saving changes in repowrapper
            await _repoWrapper.SaveAsync();
        }

        public async Task DeleteBoardByIdAsync(int id)
        {
            var board = await _repoWrapper.Boards.GetFirstOrDefaultAsync(board => board.Id == id);
             _repoWrapper.Boards.Delete(board);
            // add saving changes in repowrapper
            await _repoWrapper.SaveAsync();

        }
    }
}

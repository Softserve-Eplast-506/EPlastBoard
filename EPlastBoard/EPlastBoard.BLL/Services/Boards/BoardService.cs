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

        public async Task<Board> AddNewBoardAsync(Board newBoard)
        {
            var allBoards = await _repoWrapper.Boards.GetAllAsync();

            if (!allBoards.Contains(newBoard))
            {
                throw new ArgumentException("Board with same name is exist!");
            }

            await _repoWrapper.Boards.CreateAsync(newBoard);
            await _repoWrapper.SaveAsync();
            return newBoard;
        }

        public async Task<int> DeleteBoardByIdAsync(int id)
        {
            var board = await _repoWrapper.Boards.GetFirstOrDefaultAsync(board => board.Id == id);
            _repoWrapper.Boards.Delete(board);
            await _repoWrapper.SaveAsync();
            return id;
        }
    }
}

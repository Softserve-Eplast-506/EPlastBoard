using EPlastBoard.BLL.Interfaces.Boards;
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
    }
}

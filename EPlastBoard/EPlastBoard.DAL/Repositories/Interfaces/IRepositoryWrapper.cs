using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlastBoard.DAL.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IBoardRepository Boards { get; }
        IColumnRepository Columns { get; }
        ICardRepository   Card { get; }

        Task SaveAsync();
    }
}

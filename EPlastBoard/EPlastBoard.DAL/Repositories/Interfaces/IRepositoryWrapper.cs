using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlastBoard.DAL.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IColumnRepository Column { get; }
        IBoardRepository Boards { get; }
        public void Save();
        public Task SaveAsync();
    }
}

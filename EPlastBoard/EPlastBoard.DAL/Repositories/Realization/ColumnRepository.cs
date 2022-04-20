using EPlastBoard.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlastBoard.DAL.Repositories.Realization
{
    public class ColumnRepository : RepositoryBase<Column>, IColumnRepository
    {
        public ColumnRepository(EPlastBoardDBContext dbContext)
            : base(dbContext)
        {
        }
    }
}

using EPlastBoard.DAL.Entities;
using EPlastBoard.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlastBoard.DAL.Repositories.Realization
{
    public class BoardRepository : RepositoryBase<Board>, IBoardReapository
    {
        public BoardRepository(EPlastBoardDBContext dBContext)
            : base(dBContext) 
        {
        }
    }
}

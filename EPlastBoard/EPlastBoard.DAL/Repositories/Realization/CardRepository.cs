using EPlastBoard.DAL.Entities;
using EPlastBoard.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlastBoard.DAL.Repositories.Realization
{
    public class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(EPlastBoardDBContext ePlastDBContext) : base(ePlastDBContext)
        {
        }
    }
}

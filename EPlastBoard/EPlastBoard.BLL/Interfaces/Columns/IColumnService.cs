using EPlastBoard.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlastBoard.BLL.Interfaces.Columns
{
    public interface IColumnService
    {
        Task<Column> GetColumnByIdAsync(int id);
        Task<int> EditColumnNameAsync(Column column);
        /*Task<int> CreateColumnAsync(Column column);
        Task<Column> DeleteColumnAsync(int id);*/
    }
}

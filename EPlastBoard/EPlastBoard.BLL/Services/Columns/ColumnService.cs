using AutoMapper;
using EPlastBoard.BLL.DTO;
using EPlastBoard.BLL.Interfaces.Columns;
using EPlastBoard.DAL.Entities;
using EPlastBoard.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EPlastBoard.BLL.Services.Columns
{
    public class ColumnService : IColumnService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;


        public ColumnService(IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }

        public async Task<Column> GetColumnByIdAsync(int id)
        {
            return await _repoWrapper.Columns.GetFirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> EditColumnNameAsync(Column newColumn)
        {
            var column = await _repoWrapper.Columns.GetFirstAsync(x => x.Id == newColumn.Id);
            column.Title = newColumn.Title;
            _repoWrapper.Columns.Update(newColumn);
            await _repoWrapper.SaveAsync();

            return column.Id;
        }



        

        public async Task<IEnumerable<Column>> GetAllColumnsByBoardAsync(int boardId)
        {
            var columns = await _repoWrapper.Columns.GetAllAsync(predicate: c => c.Board.Id == boardId,
                include: source => source.Include(x => x.Cards));
            foreach (var column in columns)
            {
                column.Cards = column.Cards.OrderBy(x => x.Index).ToList();
            }
            columns = columns.OrderBy(x => x.Index).ToList();
            return columns;
        }

        public async Task UpdateColumns(IEnumerable<Column> columns)
        {
            _repoWrapper.Columns.Update(columns);
            await _repoWrapper.SaveAsync();
        }

        public async Task<Column> CreateColumnAsync(Column column)
        {
            var allColumns = await _repoWrapper.Columns.GetAllAsync();

            if (allColumns.Contains(column))
            {
                throw new ArgumentException("The same column as exist");
            }
            await _repoWrapper.Columns.CreateAsync(column);
            await _repoWrapper.SaveAsync();
            return column;
        }

        public async Task DeleteColumnAsync(int id)
        {
            var column = await _repoWrapper.Columns.GetFirstOrDefaultAsync(x => x.Id == id);
            _repoWrapper.Columns.Delete(column);
            await _repoWrapper.SaveAsync();
        }
    }
}
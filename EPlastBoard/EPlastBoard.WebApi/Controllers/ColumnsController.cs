using EPlastBoard.BLL.DTO;
using EPlastBoard.BLL.Interfaces.Columns;
using EPlastBoard.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EPlastBoard.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly IColumnService _columnService;

        public ColumnsController(IColumnService columnService)
        {
            _columnService = columnService;
        }

        [HttpGet("Columns/{boardId}")]
        public async Task<IActionResult> GetAllColumnsByBoard(int boardId)
        {
            var columns = await _columnService.GetAllColumnsByBoardAsync(boardId);
            return Ok(columns);
        }

        // GET api/<ColumnsController>/GetColumn/5
        [HttpGet("GetColumn/{id:int}")]
        public async Task<IActionResult> GetColumnById(int id)
        {
            Column column = await _columnService.GetColumnByIdAsync(id);

            if (column == null)
            {
                return NotFound();
            }
            return Ok(column);
        }

        // PUT api/<ColumnsController>/EditColumnName
        [HttpPut("EditColumnName")]
        public async Task<IActionResult> EditColumnName([FromBody] ColumnDTO column)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _columnService.EditColumnNameAsync(column);

            return Ok();
        }

        // POST api/<ColumnsController>/AddColumn
        [HttpPost("AddColumn")]
        public async Task<IActionResult> AddColumn([FromBody] ColumnDTO newColumn)
        {
            if (newColumn == null)
            {
                return BadRequest();
            }

            try
            {
                await _columnService.CreateColumnAsync(newColumn);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(newColumn);
        }

        // DELETE api/<ColumnController>/DeleteColumn/5
        [HttpDelete("DeleteColumn/{id}")]
        public async Task<IActionResult> DeleteColumnById(int id)
        {
            return Ok(await _columnService.DeleteColumnAsync(id));
        }
    }
}

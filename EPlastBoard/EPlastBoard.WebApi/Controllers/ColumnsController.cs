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

        // PUT api/<ColumnsController>/EditColumnName/5
        [HttpPut("EditColumnName/{id}")]
        public async Task<IActionResult> EditColumnName(Column column)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _columnService.EditColumnNameAsync(column);

            return Ok();
        }

        /*// POST api/<ColumnController>/AddColumn
        [HttpPost("AddColumn")]
        public async Task<IActionResult> AddColumn(Column column)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    column.Id = await _columnService.CreateColumnAsync(column);
                    return Ok(column.Id);
                }
                catch (InvalidOperationException)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<ColumnController>/DeleteColumn/5
        [HttpDelete("DeleteColumn/{id}")]
        public async Task<IActionResult> DeleteColumn(int id)
        {
            return Ok(await _columnService.DeleteColumnAsync(id));
        }*/
    }
}

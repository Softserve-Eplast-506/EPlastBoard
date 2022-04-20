using EPlastBoard.BLL.Interfaces.Boards;
using EPlastBoard.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EPlastBoard.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardsController(IBoardService boardService)
        {
            _boardService = boardService;
        }
        // GetAllBoard, GetBoardById , ChangeBoardName
        // GET: api/<BoardController>/
        [HttpGet]
        public async Task<IActionResult> GetAllBoards()
        {
            return Ok(await _boardService.GetBoardsListAsync());
        }

        // GET api/<BoardController>/GetBoard/5
        [HttpGet("GetBoard/{id:int}")]
        public async Task<IActionResult> GetBoardById(int id)
        {
            Board board = await _boardService.GetBoardByIdAsync(id);

            if (board == null)
            {
                return NotFound();
            }
            return Ok(board);
        }

        // POST api/<BoardController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BoardController>/EditBoardName/5
        [HttpPut("EditBoardName/{id}")]
        public async Task<IActionResult> EditBoardName(int id, [FromBody] string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            await _boardService.EditBoardNameAsync(id, name);

            return Ok();
        }

        // DELETE api/<BoardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

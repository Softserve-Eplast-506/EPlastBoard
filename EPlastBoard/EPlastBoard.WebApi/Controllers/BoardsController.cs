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
        public async Task<IActionResult> AddBoard([FromBody] Board newBoard)
        {
            //if (newBoard == null)
            //{
            //    return BadRequest();
            //}

            try
            {
                await _boardService.AddNewBoardAsync(newBoard);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(newBoard); 
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

        // DELETE api/<BoardController>/DeleteBoard/5
        [HttpDelete("DeleteBoard/{id}")]
        public async Task<IActionResult> DeleteBoardById(int id)
        {
            await _boardService.DeleteBoardByIdAsync(id);
            return Ok();
        }
    }
}

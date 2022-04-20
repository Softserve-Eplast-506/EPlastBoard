using EPlastBoard.BLL.Interfaces.Columns;
using Microsoft.AspNetCore.Mvc;

namespace EPlastBoard.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly IColumnService _columnService;

        public ColumnController(IColumnService columnService)
        {
            _columnService = columnService;
        }

        //[HttpGet("Columns")]
        /*public async Task<IActionResult> GetAllColumns()
        {
            //var columns = await _columnService.GetAllColumnsAsync();            
            //return Ok(columns);
        }*/
    }
}

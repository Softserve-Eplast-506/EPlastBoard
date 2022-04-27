using Microsoft.AspNetCore.Mvc;
using EPlastBoard.BLL.Interfaces.Cards;
using EPlastBoard.DAL.Entities;

namespace EPlastBoard.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        // GET: api/<CardController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetAllCards()
        {
            var cards = await _cardService.GetAllCardsAsync();
            return Ok(cards);
        }

        [HttpGet("Card/{columnId}")]
        public async Task<IActionResult> GetAllCardByColumn(int columnId)
        {
            var cards = await _cardService.GetAllCardByColumnAsync(columnId);
            return Ok(cards);
        }

        // GET api/<CardController>/5
        [HttpGet("GetCard/{id}")]
        public async Task<ActionResult<Card>> GetCardById(int id)
        {
            var cards = await _cardService.GetCardByIdAsync(id);
            return Ok(cards);
        }
        // GET api/<CardController>/5
        [HttpGet("GetCardsByColumn/{id}")]
        public async Task<ActionResult<Card>> GetCardByColumn(int id)
        {
            var cards = await _cardService.GetCardByColumnAsync(id);
            return Ok(cards);
        }

        // POST api/<CardController>
        [HttpPost("AddCard")]
        public async Task<ActionResult<Card>> AddCard(Card newCard)
        {

            if (newCard == null)
            {
                return BadRequest();
            }

            try
            {
               await _cardService.CreateCard(newCard);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(newCard);
        }

        // PUT api/<CardController>/5
        [HttpPut("EditCardName")]
        public async Task<IActionResult> EditCardName(Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _cardService.EditCardAsync(card));
        }


        // DELETE api/<CardController>/5
        [HttpDelete("DeleteCard/{id}")]
        public async Task<IActionResult> DeleteCardById(int id)
        {
            _cardService.DeleteCardAsync(id);
            return Ok(id);
        }
    }
}

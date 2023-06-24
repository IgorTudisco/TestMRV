using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TestMRV.Data;
using TestMRV.Data.Dtos;
using TestMRV.Models;
using TestMRV.Service;

namespace TestMRV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        private CardContext _context;
        private IMapper _mapper;
        //private CardService _cardService;

        public CardController(CardContext context, IMapper mapper, CardService cardService)
        {
            _context = context;
            _mapper = mapper;
            //_cardService = cardService;
        }

        /// <summary>
        /// Adiciona um card ao banco de dados
        /// </summary>
        /// <param name="cardDTO">Objeto com os campos necessários para criação de um card</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddCard([FromBody] CreateCardDTO cardDTO)
        {   
            Card card = _mapper.Map<Card>(cardDTO);
            _context.Cards.Add(card);
            //_cardService.PriceDiscount(card);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCartById), new {id = card.CardId}, card);
        }

        /// <summary>
        /// Retorna todos os cards do banco de dados
        /// </summary>
        /// <param name="skip">Valor necessário para fazer a paginação</param>
        /// <param name="take">Valor necessário para fazer a paginação</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso os cards seja encontrado com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ReadCardDTO> GetCards([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _mapper.Map<List<ReadCardDTO>>(_context.Cards.Skip(skip).Take(take));
        }

        /// <summary>
        /// Retorna um card
        /// </summary>
        /// <param name="id">Valor necessário para retornar o card específico</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso o card seja encontrado com sucesso</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCardById(int id)
        {
            var card = _context.Cards.FirstOrDefault(card => card.CardId == id);
            if(card == null) return NotFound();
            var cardDTO = _mapper.Map<ReadCardDTO>(card);
            return Ok(cardDTO);
        }

        /// <summary>
        /// Atualiza o card
        /// </summary>
        /// <param name="id">Valor necessário para achar o card específico</param>
        /// /// <param name="cardDTO">Objeto com campos necessários para atualizar o card</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso atualização seja feita com sucesso</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutCard(int id, [FromBody] UpdateCardDTO cardDTO)
        {
            var card = _context.Cards.FirstOrDefault(card => card.CardId == id);
            if(card == null) return NotFound();
            _mapper.Map(cardDTO, card);
            _context.SaveChanges();
            return NoContent();
        }

        

        /// <summary>
        /// Atualiza um campo específico do card
        /// </summary>
        /// <param name="id">Valor necessário para achar o card específico</param>
        /// /// <param name="patch">Objeto com campos necessários para atualizar o card</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso atualização seja feita com sucesso</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchCard(int id, [FromBody] JsonPatchDocument<UpdateCardDTO> patch)
        {
            var card = _context.Cards.FirstOrDefault(card => card.CardId == id);
            if (card == null) return NotFound();

            var cardUpdate = _mapper.Map<UpdateCardDTO>(card);

            patch.ApplyTo(cardUpdate, ModelState);

            if (!TryValidateModel(cardUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(cardUpdate, card);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Deleta um card
        /// </summary>
        /// <param name="id">Valor necessário para achar o card específico</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a remoção seja feita com sucesso</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteCard(int id)
        {
            var card = _context.Cards.FirstOrDefault(card => card.CardId == id);
            if (card == null) return NotFound();
            _context.Remove(card);
            _context.SaveChanges();
            return NoContent();
        }

    }
}

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
        private CardService _service;
        DateTime _dateNow = DateTime.Now;

        public CardController(CardService service)
        {
            _service = service;
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
            var card = _service.AddCard(cardDTO);
            return CreatedAtAction(nameof(GetCardById), new {id = card.CardId}, card);
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
            var listCard = _service.GetCards(skip, take);
            return listCard;
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
            var cardDTO = _service.GetCardById(id);
            if(cardDTO == null) return NotFound();
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
            var card = _service.PutCard(id, cardDTO);
            if(card == null) return NotFound();
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
            var cardUpdate = _service.PatchCard(id);
            if (cardUpdate == null) return NotFound();

            patch.ApplyTo(cardUpdate, ModelState);

            if (!TryValidateModel(cardUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _service.PatchCardSave(cardUpdate, id);
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
            var card = _service.DeleteCard(id);
            if (card == null) return NotFound();
            return NoContent();
        }

    }
}

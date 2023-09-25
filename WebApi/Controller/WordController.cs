using Application.Commands;
using Application.DTOs;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private IMediator _mediator;

        public WordController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<WordController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WordController>/5
        [HttpGet("GetWordById")]
        public async Task<WordDTO> Get([FromQuery] GetWordQuery query)
        {
            WordDTO wordDto = await _mediator.Send(query);
            return wordDto;
        }

        // POST api/<WordController>
        [HttpPost("AddWordAsync")]
        public async Task<IActionResult> AddWordAsync(AddWordCommand command)
        {
            Guid id = await _mediator.Send(command);
            return Ok(id);
        }

        // PUT api/<WordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

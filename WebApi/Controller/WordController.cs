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

        public WordController(IMediator mediator) => _mediator = mediator;



        // GET: api/<WordController>
        [HttpGet]
        public IEnumerable<string> Get() => new string[] {" "};

        [HttpGet("GetWordByTerm")]
        public async Task<WordDTO> GetById([FromQuery] GetWordByTermQuery query)
        {
            WordDTO wordDto = await _mediator.Send(query);
            return wordDto;
        }

        // GET api/<WordController>/5
        [HttpGet("GetWordById")]
        public async Task<WordDTO> GetById([FromQuery] GetWordByIdQuery query)
        {
            WordDTO wordDto = await _mediator.Send(query);
            return wordDto;
        }

        // POST api/<WordController>
        [HttpPost("AddWordAsync")]
        public async Task<IActionResult> AddWordAsync(AddWordCommand command, CancellationToken token)
        {
            Guid id = await _mediator.Send(command, token);
            return Ok(id);
        }

        // PUT api/<WordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WordController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteWordByIdCommand query)
        {
            Guid id = await _mediator.Send(query);
            return Ok(id);
        }
    }
}

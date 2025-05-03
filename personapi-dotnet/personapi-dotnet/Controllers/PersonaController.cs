using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repositories;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _repository;

        public PersonaController(IPersonaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        [HttpGet("{cc}")]
        public IActionResult GetById(int cc)
        {
            var persona = _repository.GetById(cc);
            if (persona == null) return NotFound();
            return Ok(persona);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Persona persona)
        {
            _repository.Add(persona);
            return CreatedAtAction(nameof(GetById), new { cc = persona.Cc }, persona);
        }

        [HttpPut("{cc}")]
        public IActionResult Update(int cc, [FromBody] Persona persona)
        {
            if (cc != persona.Cc) return BadRequest();
            _repository.Update(persona);
            return NoContent();
        }

        [HttpDelete("{cc}")]
        public IActionResult Delete(int cc)
        {
            _repository.Delete(cc);
            return NoContent();
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repositories;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefonoController : ControllerBase
    {
        private readonly ITelefonoRepository _repository;

        public TelefonoController(ITelefonoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        [HttpGet("{num}")]
        public IActionResult GetById(string num)
        {
            var tel = _repository.GetByNumero(num);
            if (tel == null) return NotFound();
            return Ok(tel);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Telefono tel)
        {
            _repository.Add(tel);
            return CreatedAtAction(nameof(GetById), new { num = tel.Num }, tel);
        }

        [HttpPut("{num}")]
        public IActionResult Update(string num, [FromBody] Telefono tel)
        {
            if (num != tel.Num) return BadRequest();
            _repository.Update(tel);
            return NoContent();
        }

        [HttpDelete("{num}")]
        public IActionResult Delete(string num)
        {
            _repository.Delete(num);
            return NoContent();
        }
    }
}


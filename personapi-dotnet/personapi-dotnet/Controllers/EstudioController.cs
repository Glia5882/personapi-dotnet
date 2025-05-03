using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudioController : ControllerBase
    {
        private readonly PersonaDbContext _context;

        public EstudioController(PersonaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var estudios = _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .ToList();
            return Ok(estudios);
        }

        [HttpGet("{idProf}/{ccPer}")]
        public IActionResult GetById(int idProf, int ccPer)
        {
            var estudio = _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefault(e => e.IdProf == idProf && e.CcPer == ccPer);

            if (estudio == null) return NotFound();
            return Ok(estudio);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Estudio estudio)
        {
            _context.Estudios.Add(estudio);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { idProf = estudio.IdProf, ccPer = estudio.CcPer }, estudio);
        }

        [HttpPut("{idProf}/{ccPer}")]
        public IActionResult Update(int idProf, int ccPer, [FromBody] Estudio estudio)
        {
            if (idProf != estudio.IdProf || ccPer != estudio.CcPer)
                return BadRequest("IDs no coinciden.");

            _context.Estudios.Update(estudio);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{idProf}/{ccPer}")]
        public IActionResult Delete(int idProf, int ccPer)
        {
            var estudio = _context.Estudios.Find(idProf, ccPer);
            if (estudio == null) return NotFound();

            _context.Estudios.Remove(estudio);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

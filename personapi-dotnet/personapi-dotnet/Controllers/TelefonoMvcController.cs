using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repositories;

namespace personapi_dotnet.Controllers
{
    public class TelefonoMvcController : Controller
    {
        private readonly ITelefonoRepository _repository;
        private readonly IPersonaRepository _personaRepo;
        private readonly ILogger<TelefonoMvcController> _logger;

        public TelefonoMvcController(ITelefonoRepository repository, IPersonaRepository personaRepo, ILogger<TelefonoMvcController> logger)
        {
            _repository = repository;
            _personaRepo = personaRepo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var telefonos = _repository.GetAll();
            return View(telefonos);
        }

        public IActionResult Create()
        {
            ViewBag.Personas = _personaRepo.GetAll()
                .Select(p => new { p.Cc, NombreCompleto = p.Nombre + " " + p.Apellido });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Telefono tel)
        {
            _logger.LogInformation("Intentando crear teléfono: {@Telefono}", tel);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState inválido al crear teléfono.");
                ViewBag.Personas = _personaRepo.GetAll()
                    .Select(p => new { p.Cc, NombreCompleto = p.Nombre + " " + p.Apellido });
                return View(tel);
            }

            try
            {
                _repository.Add(tel);
                _logger.LogInformation("Teléfono creado exitosamente: {@Telefono}", tel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar el teléfono en la base de datos.");
                ViewBag.Personas = _personaRepo.GetAll()
                    .Select(p => new { p.Cc, NombreCompleto = p.Nombre + " " + p.Apellido });
                ModelState.AddModelError(string.Empty, "Error al guardar el teléfono. Verifica los datos.");
                return View(tel);
            }
        }

        public IActionResult Edit(string id)
        {
            var tel = _repository.GetByNumero(id);
            if (tel == null) return NotFound();

            ViewBag.Personas = _personaRepo.GetAll()
                .Select(p => new { p.Cc, Nombre = p.Nombre + " " + p.Apellido }); // o NombreCompleto si lo definiste así

            return View(tel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Telefono tel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Personas = _personaRepo.GetAll()
                    .Select(p => new { p.Cc, Nombre = p.Nombre + " " + p.Apellido }); // Igual aquí

                return View(tel);
            }

            _repository.Update(tel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string id)
        {
            var tel = _repository.GetByNumero(id);
            if (tel == null) return NotFound();
            return View(tel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            try
            {
                _repository.Delete(id);
                _logger.LogInformation("Teléfono eliminado: {Numero}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar teléfono con número {Numero}", id);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(string id)
        {
            var telefono = _repository.GetByNumero(id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }
    }
}

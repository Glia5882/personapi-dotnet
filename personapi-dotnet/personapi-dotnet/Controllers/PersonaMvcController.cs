using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repositories;

namespace personapi_dotnet.Controllers
{
    public class PersonaMvcController : Controller
    {
        private readonly IPersonaRepository _repository;

        public PersonaMvcController(IPersonaRepository repository)
        {
            _repository = repository;
        }

        // Mostrar lista de personas
        public IActionResult Index()
        {
            var personas = _repository.GetAll();
            return View(personas);
        }

        // GET: Crear nueva persona
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crear persona
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(persona);
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Detalles
        public IActionResult Details(int id)
        {
            var persona = _repository.GetById(id);
            if (persona == null) return NotFound();
            return View(persona);
        }

        // GET: Editar
        public IActionResult Edit(int id)
        {
            var persona = _repository.GetById(id);
            if (persona == null) return NotFound();
            return View(persona);
        }

        // POST: Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(persona);
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Confirmar eliminación
        public IActionResult Delete(int id)
        {
            var persona = _repository.GetById(id);
            if (persona == null) return NotFound();
            return View(persona);
        }

        // POST: Eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

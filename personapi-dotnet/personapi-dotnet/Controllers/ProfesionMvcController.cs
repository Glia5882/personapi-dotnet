using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    public class ProfesionMvcController : Controller
    {
        private readonly PersonaDbContext _context;

        public ProfesionMvcController(PersonaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Profesions.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Profesion profesion)
        {
            if (!ModelState.IsValid) return View(profesion);
            _context.Profesions.Add(profesion);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var prof = _context.Profesions.Find(id);
            return prof == null ? NotFound() : View(prof);
        }

        [HttpPost]
        public IActionResult Edit(Profesion profesion)
        {
            if (!ModelState.IsValid) return View(profesion);
            _context.Profesions.Update(profesion);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var prof = _context.Profesions.Find(id);
            return prof == null ? NotFound() : View(prof);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var prof = _context.Profesions.Find(id);
            if (prof != null)
            {
                _context.Profesions.Remove(prof);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var prof = _context.Profesions.Find(id);
            return prof == null ? NotFound() : View(prof);
        }
    }
}

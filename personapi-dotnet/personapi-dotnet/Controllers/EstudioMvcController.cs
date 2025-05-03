using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    public class EstudioMvcController : Controller
    {
        private readonly PersonaDbContext _context;

        public EstudioMvcController(PersonaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var estudios = _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .ToList();
            return View(estudios);
        }

        public IActionResult Create()
        {
            ViewBag.Personas = _context.Personas.ToList();
            ViewBag.Profesiones = _context.Profesions.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                _context.Estudios.Add(estudio);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Personas = _context.Personas.ToList();
            ViewBag.Profesiones = _context.Profesions.ToList();
            return View(estudio);
        }

        public IActionResult Edit(int idProf, int ccPer)
        {
            var estudio = _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefault(e => e.IdProf == idProf && e.CcPer == ccPer);

            if (estudio == null) return NotFound();

            ViewBag.Personas = _context.Personas.ToList();
            ViewBag.Profesiones = _context.Profesions.ToList();
            return View(estudio);
        }

        [HttpPost]
        public IActionResult Edit(Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                _context.Estudios.Update(estudio);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Personas = _context.Personas.ToList();
            ViewBag.Profesiones = _context.Profesions.ToList();
            return View(estudio);
        }

        public IActionResult Details(int idProf, int ccPer)
        {
            var estudio = _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefault(e => e.IdProf == idProf && e.CcPer == ccPer);

            if (estudio == null) return NotFound();

            return View(estudio);
        }

        public IActionResult Delete(int idProf, int ccPer)
        {
            var estudio = _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefault(e => e.IdProf == idProf && e.CcPer == ccPer);

            if (estudio == null) return NotFound();
            return View(estudio);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int idProf, int ccPer)
        {
            var estudio = _context.Estudios.Find(idProf, ccPer);
            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

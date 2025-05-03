using personapi_dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace personapi_dotnet.Models.Repositories;
public class EstudioRepository : IEstudioRepository
{
    private readonly PersonaDbContext _context;

    public EstudioRepository(PersonaDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Estudio> GetAll() =>
        _context.Estudios
            .Include(e => e.CcPerNavigation)
            .Include(e => e.IdProfNavigation)
            .ToList();

    public Estudio? GetById(int idProf, int ccPer) =>
        _context.Estudios
            .Include(e => e.CcPerNavigation)
            .Include(e => e.IdProfNavigation)
            .FirstOrDefault(e => e.IdProf == idProf && e.CcPer == ccPer);

    public void Add(Estudio estudio)
    {
        _context.Estudios.Add(estudio);
        _context.SaveChanges();
    }

    public void Update(Estudio estudio)
    {
        _context.Estudios.Update(estudio);
        _context.SaveChanges();
    }

    public void Delete(int idProf, int ccPer)
    {
        var estudio = GetById(idProf, ccPer);
        if (estudio != null)
        {
            _context.Estudios.Remove(estudio);
            _context.SaveChanges();
        }
    }
}
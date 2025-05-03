using personapi_dotnet.Models.Entities;

public class TelefonoRepository : ITelefonoRepository
{
    private readonly PersonaDbContext _context;

    public TelefonoRepository(PersonaDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Telefono> GetAll() => _context.Telefonos.ToList();

    public Telefono GetByNumero(string numero) => _context.Telefonos.Find(numero);

    public void Add(Telefono telefono)
    {
        _context.Telefonos.Add(telefono);
        _context.SaveChanges();
    }

    public void Update(Telefono telefono)
    {
        _context.Telefonos.Update(telefono);
        _context.SaveChanges();
    }

    public void Delete(string numero)
    {
        var tel = _context.Telefonos.Find(numero);
        if (tel != null)
        {
            _context.Telefonos.Remove(tel);
            _context.SaveChanges();
        }
    }
}

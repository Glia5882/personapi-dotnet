using personapi_dotnet.Models.Entities;

public interface ITelefonoRepository
{
    IEnumerable<Telefono> GetAll();
    Telefono GetByNumero(string numero);
    void Add(Telefono telefono);
    void Update(Telefono telefono);
    void Delete(string numero);
}
using personapi_dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace personapi_dotnet.Models.Repositories;

    public interface IEstudioRepository
    {
        IEnumerable<Estudio> GetAll();
        Estudio? GetById(int idProf, int ccPer);
        void Add(Estudio estudio);
        void Update(Estudio estudio);
        void Delete(int idProf, int ccPer);
    }

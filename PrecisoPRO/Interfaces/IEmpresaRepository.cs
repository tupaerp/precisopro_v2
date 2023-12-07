using PrecisoPRO.Models;

namespace PrecisoPRO.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> GetAll();

        Task<Empresa> GetByIdAsync(int id);

        Task<Empresa> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Empresa>> GetEmpresaByCity(string cidade);

        Task<IEnumerable<Empresa>> GetAllAsyncNoTracking();

        bool Adicionar(Empresa empresa);


        bool Update(Empresa empresa);

        bool Delete(Empresa empresa);
        bool Save();
    }
}

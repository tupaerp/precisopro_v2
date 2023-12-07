using PrecisoPRO.Models;

namespace PrecisoPRO.Interfaces
{
    public interface IAssociarEmpUf
    {
        Task<IEnumerable<AssociarEmpUf>> GetAll();

        Task<AssociarEmpUf> GetByIdAsync(int id);

        Task<AssociarEmpUf> GetByIdAsyncNoTracking(int id);
        

        Task<IEnumerable<AssociarEmpUf>> GetAllAsyncNoTracking();

        bool Adicionar(AssociarEmpUf associar);


        bool Update(AssociarEmpUf associar);

        bool Delete(AssociarEmpUf associar);
        bool Save();
    }
}

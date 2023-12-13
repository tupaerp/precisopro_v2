using PrecisoPRO.Models;

namespace PrecisoPRO.Interfaces
{
    public interface INatJuridica
    {
        Task<IEnumerable<NaturezaJuridica>> GetAll();

        Task<IEnumerable<NaturezaJuridica>> GetAllAsyncNoTracking();
    }
}

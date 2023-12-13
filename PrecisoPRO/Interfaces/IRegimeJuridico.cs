using PrecisoPRO.Models;

namespace PrecisoPRO.Interfaces
{
    public interface IRegimeJuridico
    {
        Task<IEnumerable<RegimeJuridico>> GetAll();

        Task<IEnumerable<RegimeJuridico>> GetAllAsyncNoTracking();
    }
}

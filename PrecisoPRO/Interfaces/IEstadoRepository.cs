using PrecisoPRO.Models;

namespace PrecisoPRO.Interfaces
{
    public interface IEstadoRepository
    {
        Task<IEnumerable<Estado>> GetAll();

        Task<IEnumerable<Estado>> GetAllAsyncNoTracking();
        
     
       
    }
}

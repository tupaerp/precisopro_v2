using PrecisoPRO.Models.ViewModels;

namespace PrecisoPRO.Interfaces
{
    public interface ICndUf
    {
        Task<IEnumerable<CndUfViewModel>> GetAll();

        Task<IEnumerable<CndUfViewModel>> GetAllAsyncNoTracking();

       
        Task<CndUfViewModel> GetByIdAsync(int id);

        Task<CndUfViewModel> GetByIdAsyncNoTracking(int id);
    }
}

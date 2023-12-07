using Microsoft.EntityFrameworkCore;
using PrecisoPRO.Data;
using PrecisoPRO.Interfaces;
using PrecisoPRO.Models.ViewModels;

namespace PrecisoPRO.Repository
{
    public class CndUfRepository : ICndUf
    {
        //contexto do banco de dados
        private readonly PrecisoPRODbContext db;

        public CndUfRepository(PrecisoPRODbContext context)
        {
            db = context;
        }


        public async Task<IEnumerable<CndUfViewModel>> GetAll()
        {
            return await db.CndsUf.ToListAsync();
        }

        public async Task<IEnumerable<CndUfViewModel>> GetAllAsyncNoTracking()
        {
            return await db.CndsUf.AsNoTracking().OrderBy(x => x.IdEstado).ToListAsync();
        }

        public async Task<CndUfViewModel> GetByIdAsync(int id)
        {
            return await db.CndsUf.FirstOrDefaultAsync(i => i.IdRegistro == id);
        }

        public async Task<CndUfViewModel> GetByIdAsyncNoTracking(int id)
        {
            return await db.CndsUf.AsNoTracking().FirstOrDefaultAsync(i => i.IdRegistro == id);
        }
    }
}

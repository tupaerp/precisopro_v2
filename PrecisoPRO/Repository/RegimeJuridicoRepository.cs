using Microsoft.EntityFrameworkCore;
using PrecisoPRO.Data;
using PrecisoPRO.Interfaces;
using PrecisoPRO.Models;

namespace PrecisoPRO.Repository
{
    public class RegimeJuridicoRepository : IRegimeJuridico
    {
        //contexto do banco de dados
        private readonly PrecisoPRODbContext db;

        public RegimeJuridicoRepository(PrecisoPRODbContext context)
        {
            db = context;
        }
        public async Task<IEnumerable<RegimeJuridico>> GetAll()
        {
            return await db.RegimeJuridicos.ToListAsync();
        }

        public async Task<IEnumerable<RegimeJuridico>> GetAllAsyncNoTracking()
        {
            return await db.RegimeJuridicos.AsNoTracking().OrderBy(x => x.Id).ToListAsync();
        }
    }
}

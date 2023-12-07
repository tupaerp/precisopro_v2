using Microsoft.EntityFrameworkCore;
using PrecisoPRO.Data;
using PrecisoPRO.Interfaces;
using PrecisoPRO.Models;

namespace PrecisoPRO.Repository
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly PrecisoPRODbContext db;


        public EstadoRepository(PrecisoPRODbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Estado>> GetAll()
        {
            return await db.Estados.ToListAsync();
        }

        public async Task<IEnumerable<Estado>> GetAllAsyncNoTracking()
        {
            return await db.Estados.AsNoTracking().OrderBy(x => x.Descricao).ToListAsync();
        }

       
      
    }
}

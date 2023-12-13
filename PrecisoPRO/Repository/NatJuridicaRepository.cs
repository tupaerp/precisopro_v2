using Microsoft.EntityFrameworkCore;
using PrecisoPRO.Data;
using PrecisoPRO.Interfaces;
using PrecisoPRO.Models;

namespace PrecisoPRO.Repository
{
    public class NatJuridicaRepository : INatJuridica
    {
        //contexto do banco de dados
        private readonly PrecisoPRODbContext db;

        public NatJuridicaRepository(PrecisoPRODbContext context)
        {
            db = context;
        }
        public async Task<IEnumerable<NaturezaJuridica>> GetAll()
        {
            return await db.NatJuridicas.ToListAsync();
        }

        public async Task<IEnumerable<NaturezaJuridica>> GetAllAsyncNoTracking()
        {
            return await db.NatJuridicas.AsNoTracking().OrderBy(x => x.Id).ToListAsync();
        }
    }
}

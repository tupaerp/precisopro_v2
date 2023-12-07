using Microsoft.EntityFrameworkCore;
using PrecisoPRO.Data;
using PrecisoPRO.Interfaces;
using PrecisoPRO.Models;

namespace PrecisoPRO.Repository
{
    public class AssociarEmpUfRepository : IAssociarEmpUf
    {
        //contexto do banco de dados
        private readonly PrecisoPRODbContext db;

        public AssociarEmpUfRepository(PrecisoPRODbContext context)
        {
            db = context;
        }


        public bool Adicionar(AssociarEmpUf associar)
        {
            db.Add(associar);
            return Save();
        }

        public bool Delete(AssociarEmpUf associar)
        {
            db.Remove(associar);
            return Save();
        }

        public async Task<IEnumerable<AssociarEmpUf>> GetAll()
        {
            return await db.AssociarEmpresasUf.ToListAsync();
        }

        public async Task<IEnumerable<AssociarEmpUf>> GetAllAsyncNoTracking()
        {
            return await db.AssociarEmpresasUf.AsNoTracking().OrderBy(x => x.Id).ToListAsync();
        }

        public  async Task<AssociarEmpUf> GetByIdAsync(int id)
        {
            return await db.AssociarEmpresasUf.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<AssociarEmpUf> GetByIdAsyncNoTracking(int id)
        {
            return await db.AssociarEmpresasUf.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

      
        public bool Save()
        {
            var saved = db.SaveChanges();
            return saved > 0;
        }

        public bool Update(AssociarEmpUf associar)
        {
            db.Update(associar);
            return Save();
        }
    }
}

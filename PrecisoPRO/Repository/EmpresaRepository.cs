using Microsoft.EntityFrameworkCore;
using PrecisoPRO.Data;
using PrecisoPRO.Interfaces;
using PrecisoPRO.Models;

namespace PrecisoPRO.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        //contexto do banco de dados
        private readonly PrecisoPRODbContext db;

        public EmpresaRepository(PrecisoPRODbContext context)
        {
            db = context;
        }

              

        public bool Adicionar(Empresa empresa)
        {
            db.Add(empresa);
            return Save();
        }

        public bool Delete(Empresa empresa)
        {
            db.Remove(empresa);
            return Save();
        }

        public async Task<IEnumerable<Empresa>> GetAll()
        {
            return await db.Empresas.ToListAsync();
        }

        public async Task<IEnumerable<Empresa>> GetAllAsyncNoTracking()
        {
            return await db.Empresas.AsNoTracking().OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Empresa> GetByIdAsync(int id)
        {
            return await db.Empresas.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Empresa> GetByIdAsyncNoTracking(int id)
        {
            return await db.Empresas.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Empresa>> GetEmpresaByCity(string cidade)
        {
            return await db.Empresas.Where(c => c.Cidade.Contains(cidade)).ToListAsync();
        }

        public bool Save()
        {
            
            var saved = db.SaveChanges();
            return saved > 0;
        }

        public bool Update(Empresa empresa)
        {
            db.Update(empresa);
            return Save();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PrecisoPRO.Data;
using PrecisoPRO.Interfaces;
using PrecisoPRO.Models;

namespace PrecisoPRO.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //contexto do banco de dados
        private readonly PrecisoPRODbContext db;
        public UsuarioRepository(PrecisoPRODbContext context)
        {
            db = context;
        }
        public bool Adicionar(Usuario usuario)
        {
            db.Add(usuario);
            return Save();
        }

        public Usuario BuscarPorLogin(string login)
        {
            return db.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }
        public bool Delete(Usuario usuario)
        {
            db.Remove(usuario);
            return Save();
        }
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await db.Usuarios.ToListAsync();
        }

        public bool Save()
        {
            //to-do - confirmar com senha
            var saved = db.SaveChanges();
            return saved > 0;
        }

        public bool Update(Usuario usuario)
        {
            db.Update(usuario);
            return Save();
        }
    }
}
using PrecisoPRO.Models;

namespace PrecisoPRO.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();


        bool Adicionar(Usuario usuario);

        Usuario BuscarPorLogin(string login);
        bool Update(Usuario usuario);

        bool Delete(Usuario usuario);
        bool Save();
    }
}

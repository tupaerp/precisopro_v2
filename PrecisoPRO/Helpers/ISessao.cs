using PrecisoPRO.Models;
using PrecisoPRO.Models.ViewModels;

namespace PrecisoPRO.Helpers
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Usuario usuario);
        void RemoverSessaoDoUsuario();
        Usuario BuscarSessaoDoUsuario();
    }
}

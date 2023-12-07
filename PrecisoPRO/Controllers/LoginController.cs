using Microsoft.AspNetCore.Mvc;
using PrecisoPRO.Interfaces;
using PrecisoPRO.Models;
using PrecisoPRO.Models.ViewModels;

namespace PrecisoPRO.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        IEnumerable<Usuario>? listaUsuario;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Validar(UsuarioViewModel? usuarioVM, string login, string password)
        {
            if (ModelState.IsValid)
            {
                usuarioVM.Login = login;
                usuarioVM.Senha = password;
            }

            this.listaUsuario = await _usuarioRepository.GetAll();
            return View(listaUsuario);
        }


    }
}
using Microsoft.AspNetCore.Mvc;
using PrecisoPRO.Helpers;
using PrecisoPRO.Interfaces;
using PrecisoPRO.Models;
using PrecisoPRO.Models.ViewModels;

namespace PrecisoPRO.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            // Se usuario estiver logado, redirecionar para home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login"); ;
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _usuarioRepository.BuscarPorLogin(loginModel.Login);

                    if (usuario != null && usuario.Status !=2)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["Error"] = "Senha ou usuário inválidos";
                        }
                    }
                }
                return View("Index");

            }
            catch (Exception)
            {
                TempData["Error"] = "Um ou mais campos estão vazios";
                return RedirectToAction("Index");
            }
        }

    }
}
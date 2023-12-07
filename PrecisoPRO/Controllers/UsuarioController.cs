using Microsoft.AspNetCore.Mvc;
using PrecisoPRO.Interfaces;
using PrecisoPRO.Models;
using PrecisoPRO.Models.ViewModels;
using PrecisoPRO.Repository;
using X.PagedList;

namespace PrecisoPRO.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmpresaRepository _empresaRepository;
        IEnumerable<Usuario>? listaUsuario;
        IEnumerable<Empresa>? listaEmpresas;
        public UsuarioController(IUsuarioRepository usuarioRepository, IEmpresaRepository empresaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _empresaRepository = empresaRepository;
        }

        // GET: Usuario
        public async Task<IActionResult> Index(string nome, string login, int numPagina = 1)
        {
            this.listaUsuario = await _usuarioRepository.GetAll();

            if (nome != null)
            {
                this.listaUsuario = this.listaUsuario.Where(x => x.Nome.Contains(nome)).ToList();
                ViewBag.Nome = nome;
            }
            if (login != null)
            {
                this.listaUsuario = this.listaUsuario.Where(x => x.Login.Contains(login)).ToList();
                ViewBag.Login = login;
            }
            return View(this.listaUsuario.ToPagedList(numPagina, 8));

        }
        public async Task<IActionResult> Incluir()
        {
            this.listaEmpresas = await _empresaRepository.GetAll();
            ViewBag.Empresas = this.listaEmpresas.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(UsuarioViewModel? usuarioVM)
        {
            if (ModelState.IsValid)
            {

                var usuario = new Usuario
                {
                    Nome = usuarioVM.Nome,
                    Login = usuarioVM.Login.ToLower(),
                    Celular = usuarioVM.Celular,
                    Senha = usuarioVM.Senha,
                    Email = usuarioVM.Email,
                    EmpresaId = usuarioVM.EmpresaId,
                    Status = 1,
                    Data_Cad = DateTime.Now,
                    Data_Alt = DateTime.Now

                };
                try
                {
                    _usuarioRepository.Adicionar(usuario);
                    TempData["Success"] = "usuario adicionado com sucesso";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["Error"] = "Houve um erro ao adicionar o usuario, tente novamente";
                    return RedirectToAction("Index");
                }
            }

            else
            {
                ModelState.AddModelError("", "ERRO");
            }
            this.listaEmpresas = await _empresaRepository.GetAll();
            ViewBag.Empresas = this.listaEmpresas.ToList();
            return View(usuarioVM);
        }
        public async Task<IActionResult> Detalhes()
        {
            return View();
        }
    }
}
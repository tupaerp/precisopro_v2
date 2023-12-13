using Microsoft.AspNetCore.Mvc;
using PrecisoPRO.Interfaces;
using PrecisoPRO.Models;
using PrecisoPRO.Models.ViewModels;
using PrecisoPRO.Services;
using System.Data;
using System.Drawing;
using X.PagedList;

namespace PrecisoPRO.Controllers
{
    public class EmpresaController : Controller
    {
       
        //contexto do banco de dados
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly IAssociarEmpUf _associarEmpUf;
        private readonly INatJuridica _natJuridica;
        private readonly IRegimeJuridico _regimeJuridico;


        IEnumerable<Empresa>? listaEmpresas; //Lista enumerada
        IEnumerable<Estado>? listaEstados; //lista de estados
        IEnumerable<NaturezaJuridica>? listaNatJuridica; //lista as naturezas juridicas
        IEnumerable<AssociarEmpUf>? listaAssociarEmpUF;
        IEnumerable<RegimeJuridico>? listaRegimeJuridicos;
        int contSalvos = 0;
        public EmpresaController(IEmpresaRepository empresaRepository, IEstadoRepository estadoRepository, IAssociarEmpUf associarEmpUf, INatJuridica natJuridica, IRegimeJuridico regJuridico)
        {
            _empresaRepository = empresaRepository;
            _estadoRepository = estadoRepository;
            _associarEmpUf = associarEmpUf;
            _natJuridica = natJuridica;
            _regimeJuridico = regJuridico;


        }   
        public async Task<IActionResult> Index(string cnpj, string razao, string cidade, string fantasia, string estado, int numPagina = 1) 
        {
            this.listaEmpresas = await _empresaRepository.GetAllAsyncNoTracking();
            this.listaEstados = await _estadoRepository.GetAllAsyncNoTracking();
            this.listaRegimeJuridicos = await _regimeJuridico.GetAllAsyncNoTracking();
            if (cnpj != null)
            {
                this.listaEmpresas = this.listaEmpresas.Where(x => x.Cnpj.Contains(cnpj)).ToList();
                ViewBag.Cnpj = cnpj;
            }

            if (razao != null)
            {
                this.listaEmpresas = this.listaEmpresas.Where(x=>x.Razao.Contains(razao)).ToList();
                ViewBag.Razao = razao;
            }
            if(cidade != null)
            {
                this.listaEmpresas = this.listaEmpresas.Where(x => x.Cidade.Contains(cidade)).ToList();
                ViewBag.Cidade = cidade;
            }
            if (fantasia != null)
            {
                this.listaEmpresas = this.listaEmpresas.Where(x => x.Fantasia.Contains(fantasia)).ToList();
                ViewBag.Fantasia = fantasia;
            }
           
           
            if(estado !=null && estado != "")
            {
                this.listaEmpresas = this.listaEmpresas.Where(x => x.UF.Contains(estado)).ToList();
                ViewBag.Estado = estado;
            }
           
           
            //Busca os Estados
            ViewBag.Estados = this.listaEstados.ToList();
            ViewBag.RegimesJuridicos = this.listaRegimeJuridicos.ToList();
            //passa inicialmente dois parametros, o numero da pagina e o tamanho da página
            return View(this.listaEmpresas.ToPagedList(numPagina, 8));
        }

        //create
        public async Task<IActionResult> Incluir()
        {
            this.listaEstados = await _estadoRepository.GetAllAsyncNoTracking();
            this.listaNatJuridica = await _natJuridica.GetAllAsyncNoTracking();
            this.listaRegimeJuridicos = await _regimeJuridico.GetAllAsyncNoTracking();
            //Busca os Estados
            ViewBag.Estados = this.listaEstados.ToList();
            ViewBag.NatJuridica = this.listaNatJuridica.ToList();
            ViewBag.RegimeJuridico = this.listaRegimeJuridicos.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(EmpresaViewModel? empresaVM)
        {

            if (ModelState.IsValid)
            {
               
                var empresa = new Empresa
                {
                    Ie = empresaVM.Ie,
                    Im = empresaVM.Im,
                    Cnpj = empresaVM.Cnpj,
                    Razao = empresaVM.Razao,
                    NMei = empresaVM.NMei,
                    Fantasia = empresaVM.Fantasia,
                    NatJuridica = empresaVM.NatJuridica,
                    RegJuridico = empresaVM.RegJuridico,
                    AtvPrincipal = empresaVM.AtvPrincipal,
                    Cep = empresaVM.Cep,
                    Endereco = empresaVM.Endereco,
                    Numero = empresaVM.Numero,
                    Complemento = empresaVM.Complemento,
                    Bairro = empresaVM.Bairro,
                    Cidade = empresaVM.Cidade,
                    UF = empresaVM.UF,
                    Referencia = empresaVM.Referencia,
                    Principal = empresaVM.Principal,
                    Telefone = empresaVM.Telefone,
                    Celular = empresaVM.Celular,
                    Email = empresaVM.Email,
                    SitCadastral = empresaVM.SitCadastral,
                    MotDescCred = empresaVM.MotDescCred,
                    Nire = empresaVM.Nire,
                    NomeContador = empresaVM.NomeContador,
                    CrcContador = empresaVM.CrcContador,
                    NomeResponsavel = empresaVM.NomeResponsavel,
                    CrcResponsavel = empresaVM.CrcResponsavel,
                    TelAlternativo = empresaVM.TelAlternativo,
                    CelAlternativo = empresaVM.CelAlternativo,
                    EmailAlternativo = empresaVM.EmailAlternativo,
                    LoginDteSefaz = empresaVM.LoginDteSefaz,
                    SenhaDteSefaz = empresaVM.SenhaDteSefaz,
                    CpfRepresentante = empresaVM.CpfRepresentante,
                    Anotacoes = empresaVM.Anotacoes,
                    Data_Cad = DateTime.Now,
                    Data_Alt = DateTime.Now


                };
                try
                {
                    _empresaRepository.Adicionar(empresa);
                    TempData["Success"] = "Registro SALVO com sucesso";
                    return RedirectToAction("Index");
                }
                catch(Exception e)
                {
                    TempData["Error"] = "Probelmas ao salvar o registro, tente novamente";
                    return RedirectToAction("Index");
                }
               
                
            }
            else
            {
                ModelState.AddModelError("", "ERRO");
            }
            this.listaEstados = await _estadoRepository.GetAllAsyncNoTracking();
            this.listaNatJuridica = await _natJuridica.GetAllAsyncNoTracking();
            this.listaRegimeJuridicos = await _regimeJuridico.GetAllAsyncNoTracking();
            //Busca os Estados
            ViewBag.Estados = this.listaEstados.ToList();
            ViewBag.NatJuridica = this.listaNatJuridica.ToList();
            ViewBag.RegimeJuridico = this.listaRegimeJuridicos.ToList();
            return View(empresaVM);
        }

        public async Task<IActionResult>AlterarRegime(int id, string regimeNome)
        {
            //Seleciona a Empresa pelo ID e cria um objeto dela
            Empresa empresa = await _empresaRepository.GetByIdAsync(id);

            //Carrega a lista de Regimejuridico
            this.listaRegimeJuridicos = await _regimeJuridico.GetAllAsyncNoTracking();

            //Asssocia o valor do parametro a uma variavel
            string regime = regimeNome;

            //Busca o objeto em forma de var do regime juridico
            var regimeJuridico = this.listaRegimeJuridicos.FirstOrDefault(r => r.Nome == regimeNome);

            //verifica o retorno e associa a variavel idregime
            if(regimeJuridico != null)
            {
                int regimeId = regimeJuridico.Id;
                empresa.RegJuridico = regimeId;
            }

            try
            {
                _empresaRepository.Update(empresa);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Error"] = "Probelmas ao salvar o registro, tente novamente";
                return RedirectToAction("Index");
            }


            ViewBag.RegimesJuridicos = this.listaRegimeJuridicos.ToList();

            return View(empresa);
        }
        public async Task<IActionResult> AssociarIndividual(int id)
        {
            this.listaEstados = await _estadoRepository.GetAllAsyncNoTracking();
            Empresa empresa = await _empresaRepository.GetByIdAsync(id);

            //Busca os Estados
            ViewBag.Estados = this.listaEstados.ToList();
         
            return View(empresa);
        }

        [HttpPost]
        public async Task<IActionResult> AssociarIndividual(string? empresa, List<string> checkUf)
        {
            this.listaAssociarEmpUF = await _associarEmpUf.GetAllAsyncNoTracking();
            int id = int.Parse(empresa);



            if (ModelState.IsValid)
            {
                //agora percorrer o array e associar a empresa que veio no parametro a cada estado que foi selecionado
                foreach (var valorCheckbox in checkUf)
                {
                    //buscar peplo id da empresa
                    var jaExisteUf = this.listaAssociarEmpUF.Where(x => x.IdEstado.Equals(int.Parse(valorCheckbox)) && x.IdEmpresa.Equals(id)).ToList();


                    if (jaExisteUf.Count == 0)
                    {
                        var associar = new AssociarEmpUf
                        {
                            IdEmpresa = id,
                            IdEstado = int.Parse(valorCheckbox),
                            Data_Cad = DateTime.Now
                        };
                        try
                        {
                            _associarEmpUf.Adicionar(associar);
                            contSalvos++; //conta a quantidade de registros salvos

                        }
                        catch (Exception e)
                        {
                            TempData["Error"] = "Probelmas ao salvar o registro, tente novamente";
                            return RedirectToAction("Index");
                        }

                    }


                }
                if (contSalvos > 0)
                {
                    TempData["Success"] = "Registros ASSOCIADOS com sucesso: Qtd: " + contSalvos;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Warning"] = "Nenhum registro ASSOCIADO";
                    return RedirectToAction("Index");
                }




            }
            else
            {
                ModelState.AddModelError("", "ERRO");
            }
            this.listaEstados = await _estadoRepository.GetAllAsyncNoTracking();
            this.listaEmpresas = await _empresaRepository.GetAllAsyncNoTracking();

            //Busca os Estados
            ViewBag.Empresas = this.listaEmpresas.ToList();
            ViewBag.Estados = this.listaEstados.ToList();

            return View("Index");
        }
        public async Task<IActionResult> Detalhes()
        {
            this.listaEmpresas = await _empresaRepository.GetAll();
            return PartialView();
        }
    }
}


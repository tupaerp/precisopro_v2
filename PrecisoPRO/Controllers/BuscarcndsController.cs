using Microsoft.AspNetCore.Mvc;
using PrecisoPRO.Interfaces;
using PrecisoPRO.Models;
using PrecisoPRO.Models.ViewModels;

namespace PrecisoPRO.Controllers
{
    public class BuscarcndsController : Controller
    {
        //contexto do banco de dados
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly ICndUf _emitirCndUf;
        private readonly IAssociarEmpUf _associarEmpUf;
        IEnumerable<Empresa>? listaEmpresas; //Lista enumerada
        IEnumerable<Estado>? listaEstados; //lista de estados
        IEnumerable<CndUfViewModel>? listaEmissaoCndUF; //lista as cnd que precisam ser emitidas por cada estado pela empresa
        IEnumerable<AssociarEmpUf>? listaAssociarEmpUF;
        int contSalvos = 0;

        //CONSTRUTOR
        public BuscarcndsController(IEmpresaRepository empresaRepository, IEstadoRepository estadoRepository, ICndUf emitirCndUf, IAssociarEmpUf associarEmpUf)
        {
            _empresaRepository = empresaRepository;
            _estadoRepository = estadoRepository;
            _emitirCndUf = emitirCndUf;
            _associarEmpUf = associarEmpUf;
        }
        public async Task<IActionResult> Index(string cnpj, string ie, string  finalidade="CADASTRO")
        {
            this.listaEmissaoCndUF = await _emitirCndUf.GetAllAsyncNoTracking();
            this.listaEstados = await _estadoRepository.GetAllAsyncNoTracking();


            var grupos = this.listaEmissaoCndUF.GroupBy(e => e.UFEstado); //organiza pela UF da tabela estado

            // Criar uma lista para armazenar a contagem de cada estado
            var contagemPorEstado = new List<Tuple<string, int>>();

            // Iterar pelos grupos e contar a quantidade em cada grupo
            foreach (var grupo in grupos)
            {
                var estado = grupo.Key;
                var quantidade = grupo.Count();

                contagemPorEstado.Add(new Tuple<string, int>(estado, quantidade));
            }

           
            ViewBag.ContagemPorEstado = contagemPorEstado;
            ViewBag.Estados = this.listaEstados.ToList();

            return View(this.listaEmissaoCndUF);
        }

        public async Task<IActionResult> AssociarEmpresa()
        {
            this.listaEstados = await _estadoRepository.GetAllAsyncNoTracking();
            this.listaEmpresas = await _empresaRepository.GetAllAsyncNoTracking();

            //Busca os Estados
            ViewBag.Empresas = this.listaEmpresas.ToList();
            ViewBag.Estados = this.listaEstados.ToList();
            return View();
        
        }

        [HttpPost]
        public async Task<IActionResult> AssociarEmpresa(CndUfViewModel? associarEmpresa, List<string> checkUf)
        {
            this.listaAssociarEmpUF = await _associarEmpUf.GetAllAsyncNoTracking();

          

            if (ModelState.IsValid)
            {
                //agora percorrer o array e associar a empresa que veio no parametro a cada estado que foi selecionado
                foreach (var valorCheckbox in checkUf)
                {
                    //buscar peplo id da empresa
                    var jaExisteUf = this.listaAssociarEmpUF.Where(x => x.IdEstado.Equals(int.Parse(valorCheckbox)) && x.IdEmpresa.Equals(associarEmpresa.IdEmpresa)).ToList();

                  
                    if (jaExisteUf.Count == 0)
                    {
                        var associar = new AssociarEmpUf
                        {
                            IdEmpresa = associarEmpresa.IdEmpresa,
                            IdEstado = int.Parse(valorCheckbox),
                            Obs = associarEmpresa.Obs,
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
                if(contSalvos>0)
                {
                    TempData["Success"] = "Registros ASSOCIADOS com sucesso: Qtd: "+contSalvos;
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

            return View(associarEmpresa);
        }


      
    }
}

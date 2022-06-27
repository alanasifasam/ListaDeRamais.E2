using ListaDeRamais.E2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeRamais.E2.Controllers
{
    public class FunRamaisController : Controller
    {

        private readonly Banco_ramal2Context _context;

        public FunRamaisController(Banco_ramal2Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var FunRamais = await _context.FunRamais
                .Include(x => x.CodigoFunFkNavigation)
                .Include(n => n.CodigoRamalFkNavigation)
                .ToListAsync();

            return View(FunRamais);


        }


        // fazer uma busca pela lista de funcionarios de acordo com o nome e fazer o mesmo para ramais de acordo com ramal
        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {


            if (!String.IsNullOrEmpty(txtProcurar))
            {

                var listaNome =
                     await _context.FunRamais
                    .Include(x => x.CodigoFunFkNavigation)
                    .Include(x => x.CodigoRamalFkNavigation)
                    .Where(x => x.CodigoFunFkNavigation.Nome.Contains(txtProcurar))//filtra pelo nome e traz o ramal. 
                    .ToListAsync();



                return View(listaNome);
            }
            var FunRamais = await _context.FunRamais
               .Include(x => x.CodigoFunFkNavigation)
               .Include(n => n.CodigoRamalFkNavigation)
               .ToListAsync();
            return View(FunRamais);
            //fazer dois campos de busca um por nome e outro por ramal. 

        }


        [HttpGet]
        public IActionResult CriarVinculoRamais()
        {

            var FunRamaisVincular = _context.Funcionarios.ToList();
            var funRamaisVinvular = _context.Ramais.ToList();
            var viewModel = new VincularViewModel
            {
                CodigoFunFkNavigation = FunRamaisVincular,
                CodigoRamalFkNavigation = funRamaisVinvular
            };

           
            return View(viewModel);


           
        }


        [HttpPost]
        public async Task<IActionResult> CriarVinculoRamais(FunRamais funRamais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funRamais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return View(funRamais);
        }

    }
}



//IList<Funcionario> funBuscaNome = new List<Funcionario>();
//--- tentei passar por viewData.viewbag, não aceitou na view index.
//pq o metodo que acha o dado é em funcionario e a index está em funRamais


//var listaCompleta = 
// await _context.FunRamais
/// .Where(x=>x.CodigoFunFkNavigation.Nome).Include(x =>x.CodigoRamalFkNavigation.NumeroRamal)
// .ToUpper()  
// .Contains(txtProcurar.ToUpper())
// .ToListAsync();


//-- nao aceitou o numeroRmal pois é int e nao adiciona a lista. pede conversão explicita para string.
//(adicionando os parametros de include e where(x=>x.fkderamal)). da para concatenar ? qual conversão ?


// funBuscaNome = listAprocurar;
//ViewData["funBuscaNome"] = funBuscaNome;

/*var result = from funnRAMAIS in FunRamais
             group funnRAMAIS by funnRAMAIS.CodigoFunFkNavigation into agrupamento
             select agrupamento;

foreach (var item in result)
{
    foreach (var funnRAMAIS in item)
        return View(funnRAMAIS.CodigoFunFkNavigation.Nome, funnRAMAIS.CodigoRamalFkNavigation.NumeroRamal);
}

 
 
 var listAprocurar =
                    await _context.Funcionarios.Include(x => x.FunRamais)
                    .Where(x => x.Nome.ToUpper()
                    .Contains(txtProcurar.ToUpper()))
                    .ToListAsync();

                var listaFRamais = _context.Ramais.Include(x => x.FunRamais)
                    .Select(x => x.NumeroRamal).ToList();

                var ListJoin = from fun in listAprocurar
                               join numRamal in listaFRamais
                               on fun.FunRamais equals numRamal.
                               select new
                               {
                                   funcionariolista = fun,
                                   numeroRamal=numRamal
                               };

 
 
 */

using ListaDeRamais.E2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using System;
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
                                            .OrderBy(x => x.CodigoRamalFkNavigation.NumeroRamal)
                                            .ToListAsync();
            return View(FunRamais);
        }

        public IActionResult VisualizarPDF()
        {
            var listapdf = _context.FunRamais
                                            .Include(x => x.CodigoFunFkNavigation)
                                            .Include(n => n.CodigoRamalFkNavigation)
                                            .Include(x=>x.CodigoRamalFkNavigation.CodigoDepFkNavigation)
                                            .OrderBy(x => x.CodigoFunFkNavigation.Nome)
                                            .ToList();

            return new ViewAsPdf("VisualizarPDF", listapdf) { FileName = "dados.pdf" };
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {

                var listaNome =
                     await _context.FunRamais
                                    .Include(x => x.CodigoFunFkNavigation)
                                    .Include(x => x.CodigoRamalFkNavigation)
                                    .Where(x => x.CodigoFunFkNavigation.Nome.ToUpper().Contains(txtProcurar)
                                           || x.CodigoRamalFkNavigation.NumeroRamal.ToString().Contains(txtProcurar)
                                           || x.CodigoFunFkNavigation.Sobrenome.ToUpper().Contains(txtProcurar))
                                    .ToListAsync();
                return View(listaNome);
            }
            var FunRamais = await _context.FunRamais
                                           .Include(x => x.CodigoFunFkNavigation)
                                           .Include(n => n.CodigoRamalFkNavigation)
                                           .ToListAsync();
                return View(FunRamais);
           

        }


        [HttpGet]
        public IActionResult CriarVinculoRamais()
        {
            var FunRamaisVincular = _context.Funcionarios
                                            .ToList();

             var xlivres = _context.Ramais
                                   .Include(x => x.FunRamais)
                                   .Where(x => x.FunRamais.Count() == 0)
                                   .ToList();

            var viewModel = new VincularViewModel
            {
               CodigoFunFkNavigation = FunRamaisVincular,
               CodigoRamalFkNavigation = xlivres
                                   
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



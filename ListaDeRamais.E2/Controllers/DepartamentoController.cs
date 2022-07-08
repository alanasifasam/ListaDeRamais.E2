using ListaDeRamais.E2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeRamais.E2.Controllers
{
   
    public class DepartamentoController : Controller
    {
        private readonly Banco_ramal2Context _context;

        public DepartamentoController(Banco_ramal2Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _context.Ramais
                                .Include(x => x.CodigoDepFkNavigation)
                                .ToList();
            return View(list);

        }
        public IActionResult DepartamentoPDF()
        {
            var listapdf = _context.Ramais
                                .Include(x => x.CodigoDepFkNavigation)
                                .OrderBy(x=>x.CodigoDepFkNavigation.Nome)
                                
                                .ToList();

            return new ViewAsPdf("DepartamentoPDF", listapdf) { FileName = "dados.pdf" };
        }



        [HttpPost]
        public async Task<IActionResult> Index(String depbuscar)
        {
            if (!String.IsNullOrEmpty(depbuscar))
            {
                var DPbuscar = await _context.Ramais
                                             .Include(x => x.CodigoDepFkNavigation)
                                             .Where(x => x.CodigoDepFkNavigation.Nome.ToUpper().Contains(depbuscar)
                                                    ||x.NumeroRamal.ToString().Contains(depbuscar))
                                             .ToListAsync(); 
                return View(DPbuscar);
            }

            var list = _context.Ramais
                               .Include(x => x.CodigoDepFkNavigation)
                               .ToList();
            return View(list);
        }
    }
}



using ListaDeRamais.E2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var list = _context.Departamentos.Include(x => x.Ramais).ToList();
            return View(list);

        }

        [HttpPost]
        public async Task<IActionResult> Index(String depbuscar)
        {
            if (!String.IsNullOrEmpty(depbuscar))
            {

                var DPbuscar = await _context.Departamentos.Include(x => x.Ramais)
                    .Where(x => x.Nome.ToUpper().Contains(depbuscar.ToUpper()))
                    .ToListAsync();


                return View(DPbuscar);
            }

            var list = _context.Departamentos.Include(x => x.Ramais).ToList();
            return View(list);
        }

        public IActionResult Criar()
        {
            Departamento departamento = new Departamento();

            _context.Add(departamento);
            // _context.SaveChanges();

            return View();
        }

    }
}



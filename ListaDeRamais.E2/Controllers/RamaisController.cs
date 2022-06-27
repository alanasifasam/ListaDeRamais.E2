using ListaDeRamais.E2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeRamais.E2.Controllers
{
    public class RamaisController : Controller
    {
        private readonly Banco_ramal2Context _context;

        public RamaisController(Banco_ramal2Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var contextAux = _context.Ramais.Include(x => x.CodigoDepFkNavigation);
            return View(await contextAux.ToListAsync());
        }


        [HttpGet]
        public IActionResult CriarRamais()
        {

            var contextAux = _context.Departamentos.ToList();

            var viewModel = new DepartamentoRamaisFormViewModel
            {
                CodigoDepFkNavigation = contextAux,
                Ramais = new List<Ramais>() {  },
            };
            

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CriarRamais(Ramais ramal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ramal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return View(ramal);
        }


        [HttpGet]
        public IActionResult AtualizarRamais(int? id)
        {
            if (id != null)
            {
                Ramais ramal = _context.Ramais.Find(id);

                var contextAux = _context.Departamentos.ToList();

                var viewModel = new DepartamentoRamaisFormViewModel
                {
                    CodigoDepFkNavigation = contextAux,
                    NumeroRamal = ramal.NumeroRamal,
                    Senha=ramal.Senha,
                    HostIp = ramal.HostIp,
                    CodigoRamalId=ramal.CodigoRamalId
                    

                };
                return View(viewModel);
            }

            else return NotFound();
        }

       

        [HttpPost]
        public async Task<IActionResult> AtualizarRamais(int? id, Ramais ramal)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    var ramalRemove = _context.Ramais.Where(x => x.CodigoRamalId == ramal.CodigoRamalId).ToList();
                    _context.Ramais.RemoveRange(ramalRemove);
                    _context.Update(ramal);
                    await _context.SaveChangesAsync();//
                    return RedirectToAction(nameof(Index));
                }
                else return View(ramal);
            }
            else return NotFound();

        }

        [HttpGet]
        public IActionResult ExcluirRamais(int? id)
        {
            if (id != null)
            {
                Ramais ramal = _context.Ramais.Find(id);
                return View(ramal);
            }
            else return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> ExcluirRamais(int? id, Ramais ramal)
        {
            if (id != null)
            {
                _context.Remove(ramal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return NotFound();

        }


    }
}


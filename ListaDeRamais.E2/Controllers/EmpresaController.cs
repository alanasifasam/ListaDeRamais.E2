using ListaDeRamais.E2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeRamais.E2.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly Banco_ramal2Context _context;

        public EmpresaController(Banco_ramal2Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Empresas.ToListAsync());
        }


        [HttpGet]
        public IActionResult CriarEmpresa()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarEmpresa(Empresa empresas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return View(empresas);
        }


        [HttpGet]
        public IActionResult AtualizarEmpresa(int? id)
        {
            if (id != null)
            {
                Empresa empresas = _context.Empresas.Find(id);
                return View(empresas);
            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarEmpresa(int? id, Empresa empresas)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Update(empresas);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else return View(empresas);
            }
            else return NotFound();

        }

        [HttpGet]
        public IActionResult ExcluirEmpresa(int? id)
        {
            if (id != null)
            {
                Empresa empresas = _context.Empresas.Find(id);
                return View(empresas);
            }
            else return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> ExcluirEmpresa(int? id, Empresa empresas)
        {
            if (id != null)
            {
                _context.Remove(empresas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return NotFound();

        }


    }
}


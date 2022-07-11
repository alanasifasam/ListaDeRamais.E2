using ListaDeRamais.E2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeRamais.E2.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly Banco_ramal2Context _context;


        public FuncionarioController(Banco_ramal2Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var contextAux = _context.Funcionarios
                                     .Include(t => t.Telefones)
                                     .Include(x => x.FunRamais);
            return View(await contextAux.ToListAsync());
        }



        [HttpGet]

        public IActionResult CriarFuncionario()
        {

            Funcionario funcionario = new Funcionario() { };
            funcionario.Telefones.Add(new Telefone() { });
            funcionario.Telefones.Add(new Telefone() { });

            return View(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> CriarFuncionario(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {

                foreach (Telefone telefone in funcionario.Telefones)
                {
                    if (telefone.NumeroTelefone == null)
                        funcionario.Telefones.Remove(telefone);
                }

                _context.Funcionarios.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }


        [HttpGet]
        public IActionResult AtualizarFuncionario(int id)
        {
            Funcionario funcionario = _context.Funcionarios
                                              .Include(x => x.Telefones)
                                              .Where(x => x.CodigoFunId == id)
                                              .FirstOrDefault();
            return View(funcionario);

        }

        [HttpPost]
        public async Task<IActionResult> AtualizarFuncionario(int? id, Funcionario funcionario)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    List<Telefone> listTEL = _context.Telefones
                                                     .Where(x => x.CodigoFunFk == funcionario.CodigoFunId)
                                                     .ToList();
                    _context.Telefones.RemoveRange(listTEL);
                    _context.SaveChanges();

                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(funcionario);
            }
            else return NotFound();

        }

        [HttpGet]
        public IActionResult ExcluirFuncionario(int? id)
        {
            if (id != null)
            {
                Funcionario funcionario = _context.Funcionarios.Find(id);
                return View(funcionario);
            }
            else return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> ExcluirFuncionario(int? id, Funcionario funcionario)
        {
            if (id != null)
            {
                Funcionario funcionariobuscar = _context.Funcionarios.Find(id);

                List<Funcionario> funcionarioIDvinculo = _context.Funcionarios
                                                                 .Include(x => x.FunRamais)
                                                                 .Where(x => x.FunRamais.FirstOrDefault().CodigoFunFk == id)
                                                                 .ToList();

                List<Telefone> listTEL = _context.Telefones
                                                 .Where(x => x.CodigoFunFk == funcionario.CodigoFunId)
                                                 .ToList();
                funcionario = funcionariobuscar;

                if (funcionario.FunRamais == null ||  funcionario.FunRamais.Count == 0)
                {//remove telefone e funcionario sem vinculo. 
                    _context.Telefones.RemoveRange(listTEL);
                    _context.SaveChanges();

                          _context.Remove(funcionario);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));

                }else if (funcionariobuscar.FunRamais != null)
                {//remove vinculo,telefone e funcionario.

                    _context.FunRamais.RemoveRange(funcionariobuscar.FunRamais);
                    _context.Telefones.RemoveRange(listTEL);
                    await _context.SaveChangesAsync();

                    funcionario = funcionariobuscar;

                          _context.Remove(funcionario);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));


            }
            else return NotFound();

        }


    }
}




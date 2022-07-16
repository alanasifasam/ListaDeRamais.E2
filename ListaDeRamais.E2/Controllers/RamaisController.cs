using ListaDeRamais.E2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var contextAux = _context.Ramais.Include(x => x.CodigoDepFkNavigation)
                                            .OrderBy(x => x.NumeroRamal);
            return View(await contextAux.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string ProcurarEmRamais)
        {
            if (!string.IsNullOrEmpty(ProcurarEmRamais))
            {

                var listaNome = await _context.Ramais.Include(x => x.CodigoDepFkNavigation)
                                    .Where(x =>x.NumeroRamal.ToString().Contains(ProcurarEmRamais)
                                            ||x.CodigoDepFkNavigation.Nome.ToUpper().Contains(ProcurarEmRamais))
                                    .ToListAsync();
                return View(listaNome);
            }
            var contextAux = _context.Ramais.Include(x => x.CodigoDepFkNavigation)
                                             .OrderBy(x => x.NumeroRamal);
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
               var ramalExistente = _context.Ramais
                                            .Where(x=>x.NumeroRamal == ramal.NumeroRamal).ToList();
                var ramaisExistentes = _context.Ramais.ToList();
                
                
                    if (ramalExistente.Count > 0)
                    {
                    return RedirectToAction(nameof(MostrarError));
                }
                    else
                    {
                            _context.Add(ramal);
                            await _context.SaveChangesAsync();
                    }
                    return RedirectToAction(nameof(Index));   
            }
            return NotFound();
        }

        public IActionResult MostrarError()
        {
            var contextAux = _context.Ramais.OrderBy(x => x.NumeroRamal);
            return View(contextAux.ToList()); 
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
                                await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else return View(ramal);
            }
            else return NotFound();

        }

        [HttpGet]
        public IActionResult ExcluirRamais(int? id)
        {
            if (id != null )
            {
                Ramais ramal = _context.Ramais.Find(id);
                var contextAux = _context.FunRamais.ToList();
                var contextAux2 = _context.Departamentos.ToList();

                var viewModel = new DepartamentoRamaisFormViewModel
                {
                   CodigoRamalFk = contextAux.FirstOrDefault().CodigoRamalFk,
                   NumeroRamal = ramal.NumeroRamal,
                   HostIp=ramal.HostIp,
                   Senha=ramal.Senha,
                   CodigoDepFkNavigation = contextAux2,
                   Ramais = new List<Ramais>() { ramal },
                };

                return View(viewModel);
            }
            else return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> ExcluirRamais(int? id, Ramais ramal)
        {
            if (id != null  )
            {
                Ramais ramalb = _context.Ramais.Find(id);

                List<Ramais> ramalID = _context.Ramais
                                               .Include(x => x.FunRamais)
                                               .Where(x => x.FunRamais.FirstOrDefault().CodigoRamalFk == id)
                                               .ToList();
                
                if (ramalb.FunRamais == null && ramalID.Count == 0) {//exclui ramal sem vinculo 

                    ramal = ramalb;
                    _context.Remove(ramal);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                } else if (ramalb.FunRamais != null) {// se tiver vinculo, exclui vinculo e depois ramal. 

                    _context.FunRamais
                            .RemoveRange(ramalID.FirstOrDefault().FunRamais);
                    await _context.SaveChangesAsync();

                    ramal = ramalb;

                    _context.Remove(ramal);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            else return NotFound();

        }


    }
}


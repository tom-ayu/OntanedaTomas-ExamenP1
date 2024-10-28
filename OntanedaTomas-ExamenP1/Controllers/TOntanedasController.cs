using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OntanedaTomas_ExamenP1.Models;

namespace OntanedaTomas_ExamenP1.Controllers
{
    public class TOntanedasController : Controller
    {
        private readonly TOntanedaContext _context;

        public TOntanedasController(TOntanedaContext context)
        {
            _context = context;
        }

        // GET: TOntanedas
        public async Task<IActionResult> Index()
        {
            var tOntanedaContext = _context.TOntaneda.Include(t => t.Celular);
            return View(await tOntanedaContext.ToListAsync());
        }

        // GET: TOntanedas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOntaneda = await _context.TOntaneda
                .Include(t => t.Celular)
                .FirstOrDefaultAsync(m => m.IdCPU == id);
            if (tOntaneda == null)
            {
                return NotFound();
            }

            return View(tOntaneda);
        }

        // GET: TOntanedas/Create
        public IActionResult Create()
        {
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Id");
            return View();
        }

        // POST: TOntanedas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCPU,VelocidadCPU,Marca,EstaOverclokeado,FechaObtencion,IdCelular")] TOntaneda tOntaneda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tOntaneda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Id", tOntaneda.IdCelular);
            return View(tOntaneda);
        }

        // GET: TOntanedas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOntaneda = await _context.TOntaneda.FindAsync(id);
            if (tOntaneda == null)
            {
                return NotFound();
            }
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Id", tOntaneda.IdCelular);
            return View(tOntaneda);
        }

        // POST: TOntanedas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCPU,VelocidadCPU,Marca,EstaOverclokeado,FechaObtencion,IdCelular")] TOntaneda tOntaneda)
        {
            if (id != tOntaneda.IdCPU)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tOntaneda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TOntanedaExists(tOntaneda.IdCPU))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Id", tOntaneda.IdCelular);
            return View(tOntaneda);
        }

        // GET: TOntanedas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOntaneda = await _context.TOntaneda
                .Include(t => t.Celular)
                .FirstOrDefaultAsync(m => m.IdCPU == id);
            if (tOntaneda == null)
            {
                return NotFound();
            }

            return View(tOntaneda);
        }

        // POST: TOntanedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tOntaneda = await _context.TOntaneda.FindAsync(id);
            if (tOntaneda != null)
            {
                _context.TOntaneda.Remove(tOntaneda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TOntanedaExists(int id)
        {
            return _context.TOntaneda.Any(e => e.IdCPU == id);
        }
    }
}

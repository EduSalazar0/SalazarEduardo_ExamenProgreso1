using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalazarEduardo_ExamenProgreso1;
using SalazarEduardo_ExamenProgreso1.Models;

namespace SalazarEduardo_ExamenProgreso1.Controllers
{
    public class ESalazarController : Controller
    {
        private readonly Context _context;

        public ESalazarController(Context context)
        {
            _context = context;
        }

        // GET: ESalazar
        public async Task<IActionResult> Index()
        {
            var context = _context.ESalazar.Include(e => e.Celular);
            return View(await context.ToListAsync());
        }

        // GET: ESalazar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eSalazar = await _context.ESalazar
                .Include(e => e.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eSalazar == null)
            {
                return NotFound();
            }

            return View(eSalazar);
        }

        // GET: ESalazar/Create
        public IActionResult Create()
        {
            ViewData["IdCelular"] = new SelectList(_context.Celular, "Id", "Modelo");
            return View();
        }

        // POST: ESalazar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Sueldo,TieneNovia,Fecha,IdCelular")] ESalazar eSalazar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eSalazar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCelular"] = new SelectList(_context.Celular, "Id", "Modelo", eSalazar.IdCelular);
            return View(eSalazar);
        }

        // GET: ESalazar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eSalazar = await _context.ESalazar.FindAsync(id);
            if (eSalazar == null)
            {
                return NotFound();
            }
            ViewData["IdCelular"] = new SelectList(_context.Celular, "Id", "Modelo", eSalazar.IdCelular);
            return View(eSalazar);
        }

        // POST: ESalazar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Sueldo,TieneNovia,Fecha,IdCelular")] ESalazar eSalazar)
        {
            if (id != eSalazar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eSalazar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ESalazarExists(eSalazar.Id))
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
            ViewData["IdCelular"] = new SelectList(_context.Celular, "Id", "Modelo", eSalazar.IdCelular);
            return View(eSalazar);
        }

        // GET: ESalazar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eSalazar = await _context.ESalazar
                .Include(e => e.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eSalazar == null)
            {
                return NotFound();
            }

            return View(eSalazar);
        }

        // POST: ESalazar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eSalazar = await _context.ESalazar.FindAsync(id);
            if (eSalazar != null)
            {
                _context.ESalazar.Remove(eSalazar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ESalazarExists(int id)
        {
            return _context.ESalazar.Any(e => e.Id == id);
        }
    }
}

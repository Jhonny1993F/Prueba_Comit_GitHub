using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_Comit_GitHub.Data;
using Prueba_Comit_GitHub.Models;

namespace Prueba_Comit_GitHub.Controllers
{
    public class ComitsController : Controller
    {
        private readonly Prueba_Comit_GitHubContext _context;

        public ComitsController(Prueba_Comit_GitHubContext context)
        {
            _context = context;
        }

        // GET: Comits
        public async Task<IActionResult> Index()
        {
              return _context.Comit != null ? 
                          View(await _context.Comit.ToListAsync()) :
                          Problem("Entity set 'Prueba_Comit_GitHubContext.Comit'  is null.");
        }

        // GET: Comits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comit == null)
            {
                return NotFound();
            }

            var comit = await _context.Comit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comit == null)
            {
                return NotFound();
            }

            return View(comit);
        }

        // GET: Comits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaComit,Descripcion,Funciono,Calificacion")] Comit comit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comit);
        }

        // GET: Comits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comit == null)
            {
                return NotFound();
            }

            var comit = await _context.Comit.FindAsync(id);
            if (comit == null)
            {
                return NotFound();
            }
            return View(comit);
        }

        // POST: Comits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaComit,Descripcion,Funciono,Calificacion")] Comit comit)
        {
            if (id != comit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComitExists(comit.Id))
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
            return View(comit);
        }

        // GET: Comits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comit == null)
            {
                return NotFound();
            }

            var comit = await _context.Comit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comit == null)
            {
                return NotFound();
            }

            return View(comit);
        }

        // POST: Comits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comit == null)
            {
                return Problem("Entity set 'Prueba_Comit_GitHubContext.Comit'  is null.");
            }
            var comit = await _context.Comit.FindAsync(id);
            if (comit != null)
            {
                _context.Comit.Remove(comit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComitExists(int id)
        {
          return (_context.Comit?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using burioli.alessandro._5h.ECommerce.Models;

namespace burioli.alessandro._5H.ECommerce.Controllers
{
    public class PrevenditaController : Controller
    {
        private readonly dbContext _context;

        public PrevenditaController(dbContext context)
        {
            _context = context;
        }

        // GET: Prevendita
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prevendita.ToListAsync());
        }

        // GET: Prevendita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prevendita = await _context.Prevendita
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prevendita == null)
            {
                return NotFound();
            }

            return View(prevendita);
        }

        // GET: Prevendita/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prevendita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Prevendita prevendita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prevendita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prevendita);
        }

        // GET: Prevendita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prevendita = await _context.Prevendita.FindAsync(id);
            if (prevendita == null)
            {
                return NotFound();
            }
            return View(prevendita);
        }

        // POST: Prevendita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Prevendita prevendita)
        {
            if (id != prevendita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prevendita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrevenditaExists(prevendita.Id))
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
            return View(prevendita);
        }

        // GET: Prevendita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prevendita = await _context.Prevendita
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prevendita == null)
            {
                return NotFound();
            }

            return View(prevendita);
        }

        // POST: Prevendita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prevendita = await _context.Prevendita.FindAsync(id);
            if (prevendita != null)
            {
                _context.Prevendita.Remove(prevendita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
            public IActionResult Catalogo()
                {
                    return View();
                }

        private bool PrevenditaExists(int id)
        {
            return _context.Prevendita.Any(e => e.Id == id);
        }
    }
}

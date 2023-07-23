using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PojistovnaWebApp.Data;
using PojistovnaWebApp.Models;

namespace PojistovnaWebApp.Controllers
{
    public class SeznamPojisteniController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeznamPojisteniController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SeznamPojisteni
        public async Task<IActionResult> Index()
        {
              return View(await _context.SeznamPojisteni.ToListAsync());
        }

        // GET: SeznamPojisteni/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SeznamPojisteni == null)
            {
                return NotFound();
            }

            var seznamPojisteni = await _context.SeznamPojisteni
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seznamPojisteni == null)
            {
                return NotFound();
            }

            return View(seznamPojisteni);
        }

        // GET: SeznamPojisteni/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SeznamPojisteni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NazevPojisteni,Perex,Popis")] SeznamPojisteni seznamPojisteni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seznamPojisteni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seznamPojisteni);
        }

        // GET: SeznamPojisteni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SeznamPojisteni == null)
            {
                return NotFound();
            }

            var seznamPojisteni = await _context.SeznamPojisteni.FindAsync(id);
            if (seznamPojisteni == null)
            {
                return NotFound();
            }
            return View(seznamPojisteni);
        }

        // POST: SeznamPojisteni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NazevPojisteni,Perex,Popis, PojisteniOd, PojisteniDo, Cena")] SeznamPojisteni seznamPojisteni)
        {
            if (id != seznamPojisteni.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seznamPojisteni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeznamPojisteniExists(seznamPojisteni.Id))
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
            return View(seznamPojisteni);
        }

        // GET: SeznamPojisteni/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SeznamPojisteni == null)
            {
                return NotFound();
            }

            var seznamPojisteni = await _context.SeznamPojisteni
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seznamPojisteni == null)
            {
                return NotFound();
            }

            return View(seznamPojisteni);
        }

        // POST: SeznamPojisteni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SeznamPojisteni == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SeznamPojisteni'  is null.");
            }
            var seznamPojisteni = await _context.SeznamPojisteni.FindAsync(id);
            if (seznamPojisteni != null)
            {
                _context.SeznamPojisteni.Remove(seznamPojisteni);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeznamPojisteniExists(int id)
        {
          return _context.SeznamPojisteni.Any(e => e.Id == id);
        }
    }
}

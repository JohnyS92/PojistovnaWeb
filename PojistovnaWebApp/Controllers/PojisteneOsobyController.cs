using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PojistovnaWebApp.Data;
using PojistovnaWebApp.Models;

namespace PojistovnaWebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class PojisteneOsobyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PojisteneOsobyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PojisteneOsoby
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
              return View(await _context.PojisteneOsoby.ToListAsync());
        }

        // GET: PojisteneOsoby/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PojisteneOsoby == null)
            {
                return NotFound();
            }

            var pojisteneOsoby = await _context.PojisteneOsoby
                .FirstOrDefaultAsync(m => m.IdOsoby == id);
            if (pojisteneOsoby == null)
            {
                return NotFound();
            }

            return View(pojisteneOsoby);
        }

        // GET: PojisteneOsoby/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PojisteneOsoby/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOsoby,Jmeno,Prijmeni,Email,Telefon,Ulice,Mesto,Psc")] PojisteneOsoby pojisteneOsoby)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pojisteneOsoby);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pojisteneOsoby);
        }

        // GET: PojisteneOsoby/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PojisteneOsoby == null)
            {
                return NotFound();
            }

            var pojisteneOsoby = await _context.PojisteneOsoby.FindAsync(id);
            if (pojisteneOsoby == null)
            {
                return NotFound();
            }
            return View(pojisteneOsoby);
        }

        // POST: PojisteneOsoby/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOsoby,Jmeno,Prijmeni,Email,Telefon,Ulice,Mesto,Psc")] PojisteneOsoby pojisteneOsoby)
        {
            if (id != pojisteneOsoby.IdOsoby)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pojisteneOsoby);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PojisteneOsobyExists(pojisteneOsoby.IdOsoby))
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
            return View(pojisteneOsoby);
        }

        // GET: PojisteneOsoby/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PojisteneOsoby == null)
            {
                return NotFound();
            }

            var pojisteneOsoby = await _context.PojisteneOsoby
                .FirstOrDefaultAsync(m => m.IdOsoby == id);
            if (pojisteneOsoby == null)
            {
                return NotFound();
            }

            return View(pojisteneOsoby);
        }

        // POST: PojisteneOsoby/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PojisteneOsoby == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PojisteneOsoby'  is null.");
            }
            var pojisteneOsoby = await _context.PojisteneOsoby.FindAsync(id);
            if (pojisteneOsoby != null)
            {
                _context.PojisteneOsoby.Remove(pojisteneOsoby);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PojisteneOsobyExists(int id)
        {
          return _context.PojisteneOsoby.Any(e => e.IdOsoby == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationMArt.Models;

namespace WebApplicationMArt.Controllers
{
    public class UtllisateursController : Controller
    {
        private readonly MArtContext _context;

        public UtllisateursController(MArtContext context)
        {
            _context = context;
        }

        // GET: Utllisateurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utllisateurs.ToListAsync());
        }

        // GET: Utllisateurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utllisateur = await _context.Utllisateurs
                .FirstOrDefaultAsync(m => m.IdUtl == id);
            if (utllisateur == null)
            {
                return NotFound();
            }

            return View(utllisateur);
        }

        // GET: Utllisateurs/Create
        public IActionResult Register()
        {
            return View();
        }

        // POST: Utllisateurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("IdUtl,NomUtl,PrenomUtl,MotPassUtl,TelUtl,EmailUtl,AdresseUtl,PaysUtl,DomaineUtl,ImageUtl")] Utllisateur utllisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utllisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utllisateur);
        }

        // GET: Utllisateurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utllisateur = await _context.Utllisateurs.FindAsync(id);
            if (utllisateur == null)
            {
                return NotFound();
            }
            return View(utllisateur);
        }

        // POST: Utllisateurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUtl,NomUtl,PrenomUtl,MotPassUtl,TelUtl,EmailUtl,AdresseUtl,PaysUtl,DomaineUtl,ImageUtl")] Utllisateur utllisateur)
        {
            if (id != utllisateur.IdUtl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utllisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtllisateurExists(utllisateur.IdUtl))
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
            return View(utllisateur);
        }

        // GET: Utllisateurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utllisateur = await _context.Utllisateurs
                .FirstOrDefaultAsync(m => m.IdUtl == id);
            if (utllisateur == null)
            {
                return NotFound();
            }

            return View(utllisateur);
        }

        // POST: Utllisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utllisateur = await _context.Utllisateurs.FindAsync(id);
            _context.Utllisateurs.Remove(utllisateur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtllisateurExists(int id)
        {
            return _context.Utllisateurs.Any(e => e.IdUtl == id);
        }
    }
}

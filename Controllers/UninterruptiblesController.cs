using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bs.Data;
using bs.Models;

namespace bs.Controllers
{
    public class UninterruptiblesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UninterruptiblesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Uninterruptibles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Uninterruptibles.Include(u => u.Agency);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Uninterruptibles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Uninterruptibles == null)
            {
                return NotFound();
            }

            var uninterruptible = await _context.Uninterruptibles
                .Include(u => u.Agency)
                .FirstOrDefaultAsync(m => m.UpsId == id);
            if (uninterruptible == null)
            {
                return NotFound();
            }

            return View(uninterruptible);
        }

        // GET: Uninterruptibles/Create
        public IActionResult Create()
        {
            ViewData["AgencyId"] = new SelectList(_context.Agencies, "AgencyId", "AgencyName");
            return View();
        }

        // POST: Uninterruptibles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UpsId,AgencyId,UpsName,UpsModel,UpsPower,UpsManageable,UpsModules,UpsBatteries")] Uninterruptible uninterruptible)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uninterruptible);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgencyId"] = new SelectList(_context.Agencies, "AgencyId", "AgencyName", uninterruptible.AgencyId);
            return View(uninterruptible);
        }

        // GET: Uninterruptibles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Uninterruptibles == null)
            {
                return NotFound();
            }

            var uninterruptible = await _context.Uninterruptibles.FindAsync(id);
            if (uninterruptible == null)
            {
                return NotFound();
            }
            ViewData["AgencyId"] = new SelectList(_context.Agencies, "AgencyId", "AgencyName", uninterruptible.AgencyId);
            return View(uninterruptible);
        }

        // POST: Uninterruptibles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UpsId,AgencyId,UpsName,UpsModel,UpsPower,UpsManageable,UpsModules,UpsBatteries")] Uninterruptible uninterruptible)
        {
            if (id != uninterruptible.UpsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uninterruptible);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UninterruptibleExists(uninterruptible.UpsId))
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
            ViewData["AgencyId"] = new SelectList(_context.Agencies, "AgencyId", "AgencyName", uninterruptible.AgencyId);
            return View(uninterruptible);
        }

        // GET: Uninterruptibles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Uninterruptibles == null)
            {
                return NotFound();
            }

            var uninterruptible = await _context.Uninterruptibles
                .Include(u => u.Agency)
                .FirstOrDefaultAsync(m => m.UpsId == id);
            if (uninterruptible == null)
            {
                return NotFound();
            }

            return View(uninterruptible);
        }

        // POST: Uninterruptibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Uninterruptibles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Uninterruptibles'  is null.");
            }
            var uninterruptible = await _context.Uninterruptibles.FindAsync(id);
            if (uninterruptible != null)
            {
                _context.Uninterruptibles.Remove(uninterruptible);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UninterruptibleExists(int id)
        {
          return _context.Uninterruptibles.Any(e => e.UpsId == id);
        }
    }
}

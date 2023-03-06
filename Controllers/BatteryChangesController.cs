using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bs.Data;
using bs.Models;
using System.Media;
using System.Drawing;
using Microsoft.Data.SqlClient;



namespace bs.Controllers
{
    public class BatteryChangesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private List<SelectListItem> _agenciesItems;

        public BatteryChangesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BatteryChanges
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BatteryChanges.Include(b => b.Agency).Include(b => b.Uninterruptible).Include(b => b.Agency.Location);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Main()
        {


            var applicationDbContext = _context.BatteryChanges.Include(b => b.Agency).ThenInclude(b => b.Uninterruptible).Include(b => b.Agency.Location).ToList().GroupBy(a => a.UpsId).ToList()
                 .SelectMany(g => g.OrderByDescending(a => a.BatteryChangeDate).Where(x => x.BatteryChangeNext.Year == DateTime.Now.Year)).ToList();



            return View(applicationDbContext.ToList());


        }
        // GET: BatteryChanges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BatteryChanges == null)
            {
                return NotFound();
            }

            var batteryChange = await _context.BatteryChanges
                .Include(b => b.Agency)
                .Include(b => b.Uninterruptible)
                .FirstOrDefaultAsync(m => m.BatteryChangeId == id);
            if (batteryChange == null)
            {
                return NotFound();
            }

            return View(batteryChange);
        }

        // GET: BatteryChanges/Create
        public ActionResult Create(int? id)
        {

            /* ViewData["AgencyId"] = new SelectList(_context.Agencies, "AgencyId", "AgencyName")
             * ViewData["UpsId"] = new SelectList(_context.Uninterruptibles, "UpsId", "UpsModel");*/

            var agencies = _context.Agencies.ToList();
            _agenciesItems = new List<SelectListItem>();
            foreach (var item in agencies)
            {
                _agenciesItems.Add(new SelectListItem
                {
                    Text = item.AgencyName,
                    Value = item.AgencyId.ToString()

                });
            }
            
            ViewBag.agenciesItems = _agenciesItems;

            return View();
        }

        public JsonResult GetUPS(int AgencyId)
        {

            var uninterruptibles = _context.Uninterruptibles.Where(x => x.AgencyId == AgencyId).ToList();
            return Json(uninterruptibles);

        }

        // POST: BatteryChanges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BatteryChangeId,AgencyId,UpsId,BatteryChangeDate,BatteryChangeComments,ModulesInst,BatteriesInst")] BatteryChange batteryChange)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batteryChange);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgencyId"] = new SelectList(_context.Agencies, "AgencyId", "AgencyName", batteryChange.AgencyId);
            ViewData["UpsId"] = new SelectList(_context.Uninterruptibles, "UpsId", "UpsModel", batteryChange.UpsId);
            return View(batteryChange);
        }

        // GET: BatteryChanges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BatteryChanges == null)
            {
                return NotFound();
            }

            var batteryChange = await _context.BatteryChanges.FindAsync(id);
            if (batteryChange == null)
            {
                return NotFound();
            }
            ViewData["AgencyId"] = new SelectList(_context.Agencies, "AgencyId", "AgencyName", batteryChange.AgencyId);
            ViewData["UpsId"] = new SelectList(_context.Uninterruptibles, "UpsId", "UpsModel", batteryChange.UpsId);
            return View(batteryChange);
        }

        // POST: BatteryChanges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BatteryChangeId,AgencyId,UpsId,BatteryChangeDate,BatteryChangeComments,ModulesInst,BatteriesInst")] BatteryChange batteryChange)
        {
            if (id != batteryChange.BatteryChangeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batteryChange);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatteryChangeExists(batteryChange.BatteryChangeId))
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
            ViewData["AgencyId"] = new SelectList(_context.Agencies, "AgencyId", "AgencyName", batteryChange.AgencyId);
            ViewData["UpsId"] = new SelectList(_context.Uninterruptibles, "UpsId", "UpsModel", batteryChange.UpsId);
            return View(batteryChange);
        }

        // GET: BatteryChanges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BatteryChanges == null)
            {
                return NotFound();
            }

            var batteryChange = await _context.BatteryChanges
                .Include(b => b.Agency)
                .Include(b => b.Uninterruptible)
                .FirstOrDefaultAsync(m => m.BatteryChangeId == id);
            if (batteryChange == null)
            {
                return NotFound();
            }

            return View(batteryChange);
        }

        // POST: BatteryChanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BatteryChanges == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BatteryChanges'  is null.");
            }
            var batteryChange = await _context.BatteryChanges.FindAsync(id);
            if (batteryChange != null)
            {
                _context.BatteryChanges.Remove(batteryChange);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatteryChangeExists(int id)
        {
            return _context.BatteryChanges.Any(e => e.BatteryChangeId == id);
        }
    }
}

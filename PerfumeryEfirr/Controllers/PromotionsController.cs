using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PerfumeryEfirr.Data;

namespace PerfumeryEfirr.Controllers
{
    public class PromotionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PromotionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Promotions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Promotions.ToListAsync());
        }

        // GET: Promotions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotions = await _context.Promotions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promotions == null)
            {
                return NotFound();
            }

            return View(promotions);
        }

        // GET: Promotions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promotions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PercentPromotions,IdPerfume,DateBegin,DateEnd")] Promotions promotions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promotions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promotions);
        }

        // GET: Promotions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotions = await _context.Promotions.FindAsync(id);
            if (promotions == null)
            {
                return NotFound();
            }
            return View(promotions);
        }

        // POST: Promotions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PercentPromotions,IdPerfume,DateBegin,DateEnd")] Promotions promotions)
        {
            if (id != promotions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promotions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromotionsExists(promotions.Id))
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
            return View(promotions);
        }

        // GET: Promotions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotions = await _context.Promotions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promotions == null)
            {
                return NotFound();
            }

            return View(promotions);
        }

        // POST: Promotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promotions = await _context.Promotions.FindAsync(id);
            _context.Promotions.Remove(promotions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromotionsExists(int id)
        {
            return _context.Promotions.Any(e => e.Id == id);
        }
    }
}

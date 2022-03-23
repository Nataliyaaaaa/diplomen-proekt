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
    public class PerfumesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerfumesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Perfumes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Perfumes.ToListAsync());
        }

        // GET: Perfumes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfumes = await _context.Perfumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfumes == null)
            {
                return NotFound();
            }

            return View(perfumes);
        }

        // GET: Perfumes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perfumes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Quantity,Category,Photo,Price,Description,DateRegister,Type")] Perfumes perfumes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfumes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perfumes);
        }

        // GET: Perfumes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfumes = await _context.Perfumes.FindAsync(id);
            if (perfumes == null)
            {
                return NotFound();
            }
            return View(perfumes);
        }

        // POST: Perfumes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Quantity,Category,Photo,Price,Description,DateRegister,Type")] Perfumes perfumes)
        {
            if (id != perfumes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfumes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfumesExists(perfumes.Id))
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
            return View(perfumes);
        }

        // GET: Perfumes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfumes = await _context.Perfumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfumes == null)
            {
                return NotFound();
            }

            return View(perfumes);
        }

        // POST: Perfumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfumes = await _context.Perfumes.FindAsync(id);
            _context.Perfumes.Remove(perfumes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfumesExists(int id)
        {
            return _context.Perfumes.Any(e => e.Id == id);
        }
    }
}

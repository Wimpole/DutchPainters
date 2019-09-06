using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DutchPainters.Models;

namespace DutchPainters.Controllers
{
    public class EpochesController : Controller
    {
        private readonly AppDbContext _context;

        public EpochesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Epoches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Epoch.ToListAsync());
        }

        // GET: Epoches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epoch = await _context.Epoch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (epoch == null)
            {
                return NotFound();
            }

            return View(epoch);
        }

        // GET: Epoches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Epoches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StartYear,EndYear,Description")] Epoch epoch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(epoch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(epoch);
        }

        // GET: Epoches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epoch = await _context.Epoch.FindAsync(id);
            if (epoch == null)
            {
                return NotFound();
            }
            return View(epoch);
        }

        // POST: Epoches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartYear,EndYear,Description")] Epoch epoch)
        {
            if (id != epoch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(epoch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpochExists(epoch.Id))
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
            return View(epoch);
        }

        // GET: Epoches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epoch = await _context.Epoch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (epoch == null)
            {
                return NotFound();
            }

            return View(epoch);
        }

        // POST: Epoches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var epoch = await _context.Epoch.FindAsync(id);
            _context.Epoch.Remove(epoch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpochExists(int id)
        {
            return _context.Epoch.Any(e => e.Id == id);
        }
    }
}

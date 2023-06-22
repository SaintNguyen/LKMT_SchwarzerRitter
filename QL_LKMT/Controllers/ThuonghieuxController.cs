using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QL_LKMT.Models;

namespace QL_LKMT.Controllers
{
    public class ThuonghieuxController : Controller
    {
        private readonly LkmtContext _context;

        public ThuonghieuxController(LkmtContext context)
        {
            _context = context;
        }

        // GET: Thuonghieux
        public async Task<IActionResult> Index()
        {
            var lkmtContext = _context.Thuonghieus.Include(t => t.IdNhomNavigation);
            return View(await lkmtContext.ToListAsync());
        }

        // GET: Thuonghieux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Thuonghieus == null)
            {
                return NotFound();
            }

            var thuonghieu = await _context.Thuonghieus
                .Include(t => t.IdNhomNavigation)
                .FirstOrDefaultAsync(m => m.IdThuonghieu == id);
            if (thuonghieu == null)
            {
                return NotFound();
            }

            return View(thuonghieu);
        }

        // GET: Thuonghieux/Create
        public IActionResult Create()
        {
            ViewData["IdNhom"] = new SelectList(_context.Nhomsanphams, "IdNhom", "IdNhom");
            return View();
        }

        // POST: Thuonghieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThuonghieu,IdNhom,Tenthuonghieu,Ngaytao,Ngaycapnhat")] Thuonghieu thuonghieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuonghieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNhom"] = new SelectList(_context.Nhomsanphams, "IdNhom", "IdNhom", thuonghieu.IdNhom);
            return View(thuonghieu);
        }

        // GET: Thuonghieux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Thuonghieus == null)
            {
                return NotFound();
            }

            var thuonghieu = await _context.Thuonghieus.FindAsync(id);
            if (thuonghieu == null)
            {
                return NotFound();
            }
            ViewData["IdNhom"] = new SelectList(_context.Nhomsanphams, "IdNhom", "IdNhom", thuonghieu.IdNhom);
            return View(thuonghieu);
        }

        // POST: Thuonghieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThuonghieu,IdNhom,Tenthuonghieu,Ngaytao,Ngaycapnhat")] Thuonghieu thuonghieu)
        {
            if (id != thuonghieu.IdThuonghieu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuonghieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuonghieuExists(thuonghieu.IdThuonghieu))
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
            ViewData["IdNhom"] = new SelectList(_context.Nhomsanphams, "IdNhom", "IdNhom", thuonghieu.IdNhom);
            return View(thuonghieu);
        }

        // GET: Thuonghieux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Thuonghieus == null)
            {
                return NotFound();
            }

            var thuonghieu = await _context.Thuonghieus
                .Include(t => t.IdNhomNavigation)
                .FirstOrDefaultAsync(m => m.IdThuonghieu == id);
            if (thuonghieu == null)
            {
                return NotFound();
            }

            return View(thuonghieu);
        }

        // POST: Thuonghieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Thuonghieus == null)
            {
                return Problem("Entity set 'LkmtContext.Thuonghieus'  is null.");
            }
            var thuonghieu = await _context.Thuonghieus.FindAsync(id);
            if (thuonghieu != null)
            {
                _context.Thuonghieus.Remove(thuonghieu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuonghieuExists(int id)
        {
          return _context.Thuonghieus.Any(e => e.IdThuonghieu == id);
        }
    }
}

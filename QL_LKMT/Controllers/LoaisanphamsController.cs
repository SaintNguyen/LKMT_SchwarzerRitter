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
    public class LoaisanphamsController : Controller
    {
        private readonly LkmtContext _context;

        public LoaisanphamsController(LkmtContext context)
        {
            _context = context;
        }

        // GET: Loaisanphams
        public async Task<IActionResult> Index()
        {
            var lkmtContext = _context.Loaisanphams.Include(l => l.IdNhomNavigation);
            return View(await lkmtContext.ToListAsync());
        }

        // GET: Loaisanphams/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Loaisanphams == null)
            {
                return NotFound();
            }

            var loaisanpham = await _context.Loaisanphams
                .Include(l => l.IdNhomNavigation)
                .FirstOrDefaultAsync(m => m.IdLoai == id);
            if (loaisanpham == null)
            {
                return NotFound();
            }

            return View(loaisanpham);
        }

        // GET: Loaisanphams/Create
        public IActionResult Create()
        {
            ViewData["IdNhom"] = new SelectList(_context.Nhomsanphams, "IdNhom", "IdNhom");
            return View();
        }

        // POST: Loaisanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoai,IdNhom,Tenloai,Ngaytao,Ngaycapnhat")] Loaisanpham loaisanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaisanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNhom"] = new SelectList(_context.Nhomsanphams, "IdNhom", "IdNhom", loaisanpham.IdNhom);
            return View(loaisanpham);
        }

        // GET: Loaisanphams/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Loaisanphams == null)
            {
                return NotFound();
            }

            var loaisanpham = await _context.Loaisanphams.FindAsync(id);
            if (loaisanpham == null)
            {
                return NotFound();
            }
            ViewData["IdNhom"] = new SelectList(_context.Nhomsanphams, "IdNhom", "IdNhom", loaisanpham.IdNhom);
            return View(loaisanpham);
        }

        // POST: Loaisanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdLoai,IdNhom,Tenloai,Ngaytao,Ngaycapnhat")] Loaisanpham loaisanpham)
        {
            if (id != loaisanpham.IdLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaisanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaisanphamExists(loaisanpham.IdLoai))
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
            ViewData["IdNhom"] = new SelectList(_context.Nhomsanphams, "IdNhom", "IdNhom", loaisanpham.IdNhom);
            return View(loaisanpham);
        }

        // GET: Loaisanphams/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Loaisanphams == null)
            {
                return NotFound();
            }

            var loaisanpham = await _context.Loaisanphams
                .Include(l => l.IdNhomNavigation)
                .FirstOrDefaultAsync(m => m.IdLoai == id);
            if (loaisanpham == null)
            {
                return NotFound();
            }

            return View(loaisanpham);
        }

        // POST: Loaisanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Loaisanphams == null)
            {
                return Problem("Entity set 'LkmtContext.Loaisanphams'  is null.");
            }
            var loaisanpham = await _context.Loaisanphams.FindAsync(id);
            if (loaisanpham != null)
            {
                _context.Loaisanphams.Remove(loaisanpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaisanphamExists(string id)
        {
          return _context.Loaisanphams.Any(e => e.IdLoai == id);
        }
    }
}

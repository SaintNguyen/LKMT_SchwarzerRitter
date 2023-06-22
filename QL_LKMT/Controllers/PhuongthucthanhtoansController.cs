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
    public class PhuongthucthanhtoansController : Controller
    {
        private readonly LkmtContext _context;

        public PhuongthucthanhtoansController(LkmtContext context)
        {
            _context = context;
        }

        // GET: Phuongthucthanhtoans
        public async Task<IActionResult> Index()
        {
            var lkmtContext = _context.Phuongthucthanhtoans.Include(p => p.IdKhachhangNavigation).Include(p => p.IdSanphamNavigation);
            return View(await lkmtContext.ToListAsync());
        }

        // GET: Phuongthucthanhtoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Phuongthucthanhtoans == null)
            {
                return NotFound();
            }

            var phuongthucthanhtoan = await _context.Phuongthucthanhtoans
                .Include(p => p.IdKhachhangNavigation)
                .Include(p => p.IdSanphamNavigation)
                .FirstOrDefaultAsync(m => m.IdThanhtoan == id);
            if (phuongthucthanhtoan == null)
            {
                return NotFound();
            }

            return View(phuongthucthanhtoan);
        }

        // GET: Phuongthucthanhtoans/Create
        public IActionResult Create()
        {
            ViewData["IdKhachhang"] = new SelectList(_context.Khachhangs, "IdKhachhang", "IdKhachhang");
            ViewData["IdSanpham"] = new SelectList(_context.Sanphams, "IdSanpham", "IdSanpham");
            return View();
        }

        // POST: Phuongthucthanhtoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThanhtoan,Tenthanhtoan,IdKhachhang,IdSanpham")] Phuongthucthanhtoan phuongthucthanhtoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phuongthucthanhtoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKhachhang"] = new SelectList(_context.Khachhangs, "IdKhachhang", "IdKhachhang", phuongthucthanhtoan.IdKhachhang);
            ViewData["IdSanpham"] = new SelectList(_context.Sanphams, "IdSanpham", "IdSanpham", phuongthucthanhtoan.IdSanpham);
            return View(phuongthucthanhtoan);
        }

        // GET: Phuongthucthanhtoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Phuongthucthanhtoans == null)
            {
                return NotFound();
            }

            var phuongthucthanhtoan = await _context.Phuongthucthanhtoans.FindAsync(id);
            if (phuongthucthanhtoan == null)
            {
                return NotFound();
            }
            ViewData["IdKhachhang"] = new SelectList(_context.Khachhangs, "IdKhachhang", "IdKhachhang", phuongthucthanhtoan.IdKhachhang);
            ViewData["IdSanpham"] = new SelectList(_context.Sanphams, "IdSanpham", "IdSanpham", phuongthucthanhtoan.IdSanpham);
            return View(phuongthucthanhtoan);
        }

        // POST: Phuongthucthanhtoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThanhtoan,Tenthanhtoan,IdKhachhang,IdSanpham")] Phuongthucthanhtoan phuongthucthanhtoan)
        {
            if (id != phuongthucthanhtoan.IdThanhtoan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phuongthucthanhtoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhuongthucthanhtoanExists(phuongthucthanhtoan.IdThanhtoan))
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
            ViewData["IdKhachhang"] = new SelectList(_context.Khachhangs, "IdKhachhang", "IdKhachhang", phuongthucthanhtoan.IdKhachhang);
            ViewData["IdSanpham"] = new SelectList(_context.Sanphams, "IdSanpham", "IdSanpham", phuongthucthanhtoan.IdSanpham);
            return View(phuongthucthanhtoan);
        }

        // GET: Phuongthucthanhtoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Phuongthucthanhtoans == null)
            {
                return NotFound();
            }

            var phuongthucthanhtoan = await _context.Phuongthucthanhtoans
                .Include(p => p.IdKhachhangNavigation)
                .Include(p => p.IdSanphamNavigation)
                .FirstOrDefaultAsync(m => m.IdThanhtoan == id);
            if (phuongthucthanhtoan == null)
            {
                return NotFound();
            }

            return View(phuongthucthanhtoan);
        }

        // POST: Phuongthucthanhtoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Phuongthucthanhtoans == null)
            {
                return Problem("Entity set 'LkmtContext.Phuongthucthanhtoans'  is null.");
            }
            var phuongthucthanhtoan = await _context.Phuongthucthanhtoans.FindAsync(id);
            if (phuongthucthanhtoan != null)
            {
                _context.Phuongthucthanhtoans.Remove(phuongthucthanhtoan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhuongthucthanhtoanExists(int id)
        {
          return _context.Phuongthucthanhtoans.Any(e => e.IdThanhtoan == id);
        }
    }
}

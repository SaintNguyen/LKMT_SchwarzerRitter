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
    public class SanphamsController : Controller
    {
        private readonly LkmtContext _context;

        public SanphamsController(LkmtContext context)
        {
            _context = context;
        }

        // GET: Sanphams
        public async Task<IActionResult> Index()
        {
            var lkmtContext = _context.Sanphams.Include(s => s.IdLoaiNavigation).Include(s => s.IdThuonghieuNavigation);
            return View(await lkmtContext.ToListAsync());
        }

        // GET: Sanphams/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Sanphams == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .Include(s => s.IdLoaiNavigation)
                .Include(s => s.IdThuonghieuNavigation)
                .FirstOrDefaultAsync(m => m.IdSanpham == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Sanphams/Create
        public IActionResult Create()
        {
            ViewData["IdLoai"] = new SelectList(_context.Loaisanphams, "IdLoai", "IdLoai");
            ViewData["IdThuonghieu"] = new SelectList(_context.Thuonghieus, "IdThuonghieu", "IdThuonghieu");
            return View();
        }

        // POST: Sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSanpham,Tensanpham,IdLoai,Gia,IdThuonghieu,Baohanh,Khuyenmai,Hinh,Mota,Ngaytao,Ngaycapnhat,IdThanhtoan")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoai"] = new SelectList(_context.Loaisanphams, "IdLoai", "IdLoai", sanpham.IdLoai);
            ViewData["IdThuonghieu"] = new SelectList(_context.Thuonghieus, "IdThuonghieu", "IdThuonghieu", sanpham.IdThuonghieu);
            return View(sanpham);
        }

        // GET: Sanphams/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Sanphams == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["IdLoai"] = new SelectList(_context.Loaisanphams, "IdLoai", "IdLoai", sanpham.IdLoai);
            ViewData["IdThuonghieu"] = new SelectList(_context.Thuonghieus, "IdThuonghieu", "IdThuonghieu", sanpham.IdThuonghieu);
            return View(sanpham);
        }

        // POST: Sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdSanpham,Tensanpham,IdLoai,Gia,IdThuonghieu,Baohanh,Khuyenmai,Hinh,Mota,Ngaytao,Ngaycapnhat,IdThanhtoan")] Sanpham sanpham)
        {
            if (id != sanpham.IdSanpham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.IdSanpham))
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
            ViewData["IdLoai"] = new SelectList(_context.Loaisanphams, "IdLoai", "IdLoai", sanpham.IdLoai);
            ViewData["IdThuonghieu"] = new SelectList(_context.Thuonghieus, "IdThuonghieu", "IdThuonghieu", sanpham.IdThuonghieu);
            return View(sanpham);
        }

        // GET: Sanphams/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Sanphams == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .Include(s => s.IdLoaiNavigation)
                .Include(s => s.IdThuonghieuNavigation)
                .FirstOrDefaultAsync(m => m.IdSanpham == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Sanphams == null)
            {
                return Problem("Entity set 'LkmtContext.Sanphams'  is null.");
            }
            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham != null)
            {
                _context.Sanphams.Remove(sanpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(string id)
        {
          return _context.Sanphams.Any(e => e.IdSanpham == id);
        }
    }
}

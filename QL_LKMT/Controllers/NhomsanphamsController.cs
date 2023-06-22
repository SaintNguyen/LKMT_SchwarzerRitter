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
    public class NhomsanphamsController : Controller
    {
        private readonly LkmtContext _context;

        public NhomsanphamsController(LkmtContext context)
        {
            _context = context;
        }

        // GET: Nhomsanphams
        public async Task<IActionResult> Index()
        {
              return View(await _context.Nhomsanphams.ToListAsync());
        }

        // GET: Nhomsanphams/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhomsanphams == null)
            {
                return NotFound();
            }

            var nhomsanpham = await _context.Nhomsanphams
                .FirstOrDefaultAsync(m => m.IdNhom == id);
            if (nhomsanpham == null)
            {
                return NotFound();
            }

            return View(nhomsanpham);
        }

        // GET: Nhomsanphams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhomsanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNhom,Tennhom,Ngaytao,Ngaycapnhat")] Nhomsanpham nhomsanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhomsanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhomsanpham);
        }

        // GET: Nhomsanphams/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhomsanphams == null)
            {
                return NotFound();
            }

            var nhomsanpham = await _context.Nhomsanphams.FindAsync(id);
            if (nhomsanpham == null)
            {
                return NotFound();
            }
            return View(nhomsanpham);
        }

        // POST: Nhomsanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdNhom,Tennhom,Ngaytao,Ngaycapnhat")] Nhomsanpham nhomsanpham)
        {
            if (id != nhomsanpham.IdNhom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhomsanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhomsanphamExists(nhomsanpham.IdNhom))
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
            return View(nhomsanpham);
        }

        // GET: Nhomsanphams/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nhomsanphams == null)
            {
                return NotFound();
            }

            var nhomsanpham = await _context.Nhomsanphams
                .FirstOrDefaultAsync(m => m.IdNhom == id);
            if (nhomsanpham == null)
            {
                return NotFound();
            }

            return View(nhomsanpham);
        }

        // POST: Nhomsanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nhomsanphams == null)
            {
                return Problem("Entity set 'LkmtContext.Nhomsanphams'  is null.");
            }
            var nhomsanpham = await _context.Nhomsanphams.FindAsync(id);
            if (nhomsanpham != null)
            {
                _context.Nhomsanphams.Remove(nhomsanpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhomsanphamExists(string id)
        {
          return _context.Nhomsanphams.Any(e => e.IdNhom == id);
        }
    }
}

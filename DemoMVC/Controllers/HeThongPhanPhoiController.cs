using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models.Entities;
using DemoMVC.Models.Process;

namespace DemoMVC.Controllers
{
    public class HeThongPhanPhoiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeThongPhanPhoiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HeThongPhanPhoi
        public async Task<IActionResult> Index()
        {
            return View(await _context.HeThongPhanPhoi.ToListAsync());
        }

        // GET: HeThongPhanPhoi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heThongPhanPhoi = await _context.HeThongPhanPhoi
                .FirstOrDefaultAsync(m => m.MaHTPP == id);
            if (heThongPhanPhoi == null)
            {
                return NotFound();
            }

            return View(heThongPhanPhoi);
        }

        // GET: HeThongPhanPhoi/Create
        public IActionResult Create()
        {
            //lay ra ban ghi moi nhat cua HTPP
            var htpp = _context.HeThongPhanPhoi
            .OrderByDescending(h => h.MaHTPP)
            .FirstOrDefault();
            //neu htpp = nul thi gan ma htpp = htpp0
            var maHTPP = htpp == null ? "HTPP0" : htpp.MaHTPP;
            //goi thoi phuong thuc sinh id tu dong
            var autoGenerateID = new AutoGenerateCode();
            var newmaHTPP = autoGenerateID.GenerateID(maHTPP);
            var newHTPP = new HeThongPhanPhoi
            {
                MaHTPP = newmaHTPP
            };
            return View(newHTPP);
        }

        // POST: HeThongPhanPhoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHTPP,TenHTPP")] HeThongPhanPhoi heThongPhanPhoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(heThongPhanPhoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(heThongPhanPhoi);
        }

        // GET: HeThongPhanPhoi/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heThongPhanPhoi = await _context.HeThongPhanPhoi.FindAsync(id);
            if (heThongPhanPhoi == null)
            {
                return NotFound();
            }
            return View(heThongPhanPhoi);
        }

        // POST: HeThongPhanPhoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHTPP,TenHTPP")] HeThongPhanPhoi heThongPhanPhoi)
        {
            if (id != heThongPhanPhoi.MaHTPP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(heThongPhanPhoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeThongPhanPhoiExists(heThongPhanPhoi.MaHTPP))
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
            return View(heThongPhanPhoi);
        }

        // GET: HeThongPhanPhoi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heThongPhanPhoi = await _context.HeThongPhanPhoi
                .FirstOrDefaultAsync(m => m.MaHTPP == id);
            if (heThongPhanPhoi == null)
            {
                return NotFound();
            }

            return View(heThongPhanPhoi);
        }

        // POST: HeThongPhanPhoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var heThongPhanPhoi = await _context.HeThongPhanPhoi.FindAsync(id);
            if (heThongPhanPhoi != null)
            {
                _context.HeThongPhanPhoi.Remove(heThongPhanPhoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeThongPhanPhoiExists(string id)
        {
            return _context.HeThongPhanPhoi.Any(e => e.MaHTPP == id);
        }
    }
}

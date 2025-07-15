
using DemoMVC.Data;
using DemoMVC.Models;
using DemoMVC.Models.Process;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMvc.Controllers
{
    public class HeThongPhanPhoiController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HeThongPhanPhoiController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.HeThongPhanPhoi.ToListAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            //lay ra ban ghi moi nhat cua HTPP
            var htpp = _context.HeThongPhanPhoi
            .OrderByDescending(m => m.MaHTPP)
            .FirstOrDefault();
            //lay maHTPP cuoi cung, neu null thi lay ma mac dinh
            var maHTPP = htpp == null ? "HTPP000" : htpp.MaHTPP;
            //Goi phuong thuc autogenerate code de sinh ma
            var AutoGenerateCode = new AutoGenerateCode();
            //Truyen ma moi den view de hien thi
            var newMaHTPP = AutoGenerateCode.GenerateID(maHTPP);
            var newHTPP = new HeThongPhanPhoi
            {
                MaHTPP = newMaHTPP
            };
            return View(newHTPP);   
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("MaHTPP, TenHTPP")] HeThongPhanPhoi htpp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(htpp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(htpp);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HeThongPhanPhoi == null)
            {
                return NotFound();
            }
            var htpp = await _context.HeThongPhanPhoi.FindAsync(id);
            if (htpp == null)
            {
                return NotFound();
            }
            return View(htpp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(string id, [Bind("MaHTPP, TenHTPP")] HeThongPhanPhoi htpp)
        {
            if (id != htpp.MaHTPP)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(htpp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HTPPExits(htpp.MaHTPP))
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
            return View(htpp);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HeThongPhanPhoi == null)
            {
                return NotFound();
            }
            var htpp = await _context.HeThongPhanPhoi
            .FirstOrDefaultAsync(m => m.MaHTPP == id);

            if (htpp == null)
            {
                return NotFound();
            }
            return View(htpp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HeThongPhanPhoi == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Person' is null.");
            }
            var htpp = await _context.HeThongPhanPhoi.FindAsync(id);
            if (htpp != null)
            {
                _context.Remove(htpp);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HTPPExits(string id)
        {
            return (_context.HeThongPhanPhoi?.Any(e => e.MaHTPP == id)).GetValueOrDefault();
        }
        // public IActionResult Index(string MaHTPP, string TenHTPP)
        // {
        //     string strOutput = "Xin chao " + MaHTPP + " - " + TenHTPP;
        //     ViewBag.infoHTPP = strOutput;
        //     return View();
        // }
    }
}

using DemoMvc.Data;
using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMvc.Controllers
{
    public class HeThongPhanPhoiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AutoGenerateCode _autoGenerateCode;
        public HeThongPhanPhoiController(ApplicationDbContext context, AutoGenerateCode autoGenerateCode)
        {
            _context = context;
            _autoGenerateCode = autoGenerateCode;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.HeThongPhanPhoi.ToListAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            //lay ma cuoi cung trong database, sap xep giam dan
            var lastHTPP = _context.HeThongPhanPhoi
            .OrderByDescending(m => m.MaHTPP)
            .FirstOrDefault();
            //lay maHTPP cuoi cung, neu null thi lay ma mac dinh
            var lastMaHTPP = lastHTPP?.MaHTPP ?? "HTPP000";
            //Goi phuong thuc autogenerate code de sinh ma
            var newMaHTPP = _autoGenerateCode.GenerateCode(lastMaHTPP);
            //Truyen ma moi den view de hien thi
            ViewBag.NewMaHTPP =  newMaHTPP; 
            return View();
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

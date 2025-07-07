using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{
    public class DaiLyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DaiLy dl)
        {
            string strOutput = "Xin chao " + dl.MaDaiLy + " - " + dl.TenDaiLy + " - " + dl.DiaChi + " - " + dl.NguoiDaiDien + " - " + dl.DienThoai + " - " + dl.MaHTPP;
            ViewBag.infoDaiLy = strOutput;
            return View();
        }
    }
}
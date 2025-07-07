using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{
    public class HeThongPhanPhoiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string MaHTPP, string TenHTPP)
        {
            string strOutput = "Xin chao " + MaHTPP + " - " + TenHTPP;
            ViewBag.infoHTPP = strOutput;
            return View();
        }
    }
}

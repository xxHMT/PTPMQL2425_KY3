using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Text.Encodings.Web;

namespace DemoMVC.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Index(Person ps)
        {
            string strOutput = "Xin chao " + ps.PersonID + "-" + ps.FullName + "-" + ps.Address;
            ViewBag.InfoPerson = strOutput;
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }
    }
}
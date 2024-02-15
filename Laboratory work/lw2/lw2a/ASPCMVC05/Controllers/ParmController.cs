using ASPCMVC05.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPCMVC05.Controllers
{
    public class ParmController : Controller
    {

        public IActionResult Index(string Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        public IActionResult Uri01(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        public IActionResult Uri02(int? Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        public IActionResult Uri03(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        public IActionResult Uri04(DateTime Id)
        {
            ViewBag.Id = Id;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
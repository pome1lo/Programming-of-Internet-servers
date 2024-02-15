using ASPCMVC03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPCMVC03.Controllers
{
    public class StartController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult One() => View();


        public IActionResult Two() => View();

        public IActionResult Three() => View();




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
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
    }
}
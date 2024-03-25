using ASPCMVC04.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPCMVC04.Controllers
{
    public class StatusController : Controller
    { 
        public IActionResult Index() => View();

        public IActionResult S200() =>  StatusCode(GenerateStatusCode(200, 300));
        public IActionResult S300() =>  StatusCode(GenerateStatusCode(300, 400));
        public IActionResult S500() =>  StatusCode(GenerateStatusCode(500, 600), "Devided by zero");

        private int GenerateStatusCode(int start, int end) => new Random().Next(start, end);
    }
}
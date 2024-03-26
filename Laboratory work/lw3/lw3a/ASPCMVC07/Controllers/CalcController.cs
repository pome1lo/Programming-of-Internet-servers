using ASPCMVC07.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPCMVC07.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult Index() => View();

        [HttpGet] public IActionResult Sum() => ChangeView("+");
        [HttpGet] public IActionResult Sub() => ChangeView("-");
        [HttpGet] public IActionResult Mul() => ChangeView("/");
        [HttpGet] public IActionResult Div() => ChangeView("*");

        private IActionResult ChangeView(string operation)
        {
            ViewBag.press = operation;
            return View("Index");
        }

        [HttpPost] public IActionResult Sum([FromForm] string? x, [FromForm] string? y) => Calculate(x, y, "+");
        [HttpPost] public IActionResult Sub([FromForm] string? x, [FromForm] string? y) => Calculate(x, y, "-");
        [HttpPost] public IActionResult Mul([FromForm] string? x, [FromForm] string? y) => Calculate(x, y, "*");
        [HttpPost] public IActionResult Div([FromForm] string? x, [FromForm] string? y) => Calculate(x, y, "/");


        private ViewResult Calculate(string? x, string? y, string operation)
        {
            if (!string.IsNullOrWhiteSpace(x) && !string.IsNullOrWhiteSpace(y))
            {
                try
                {
                    ViewBag.press = operation;

                    float castX = float.Parse(x);
                    float castY = float.Parse(y);
                     
                    ViewBag.x = castX;
                    ViewBag.y = castY;

                    switch (operation)
                    {
                        case "+": ViewBag.z = castX + castY; break;
                        case "/": ViewBag.z = castX / castY; break;
                        case "-": ViewBag.z = castX - castY; break;
                        case "*": ViewBag.z = castX * castY; break;
                        default: break;
                    }
                }
                catch (Exception err)
                {
                    ViewBag.Error = err.Message;
                    ViewBag.z = "0,00";
                }
            }
            return View("Index");
        } 
    }
}

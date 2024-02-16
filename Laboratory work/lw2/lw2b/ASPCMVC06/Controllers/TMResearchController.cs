using Microsoft.AspNetCore.Mvc;

namespace ASPCMVC06.Controllers
{
    public class TMResearchController : Controller
    {
        public IActionResult M01(String str) => Content("GET:M01 " + str);

        public IActionResult M02(String str) => Content("GET:M02 " + str);

        public IActionResult M03(String str) => Content("GET:M03");

        public IActionResult MXX() => Content("GET:MXX");
    }
}

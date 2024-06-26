using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Models;
using System.Diagnostics;

namespace SimpleCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Calculator cal)
        {

            int a, b;
            a = cal.num1;
            b = cal.num2;
            if(cal.calculate == "-")
            {
                cal.result = a - b;
            } 
            else if(cal.calculate == "+")
            {
                cal.result = a + b;
            }
            else if(cal.calculate == "*")
            {
                cal.result = a * b;
            }
            else if (cal.calculate == "/")
            {
                cal.result = a / b;
            } 
            else if (cal.calculate == "^")
            {
                int pow = 1;
                for(int i = 1; i <= cal.num2; i++) 
                {
                    pow = pow * cal.num1;
                }
                cal.result = pow;
            }
            ViewData["result"] = cal.result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

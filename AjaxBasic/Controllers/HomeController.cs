using AjaxBasic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AjaxBasic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        NorthwindContext? _context = null;

        public HomeController(ILogger<HomeController> logger, NorthwindContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult CallGreet()
        {
            return View();
        }
        public IActionResult jQueryCallGreet()
        {
            return View();
        }
        public IActionResult FetchCallGreet()
        {
            return View();
        }
        public IActionResult CallCheckName()
        {
            return View();
        }
        public IActionResult jQueryCallCheckName()
        {
            return View();
        }
        public IActionResult FetchCallCheckName()
        {
            return View();
        }
        public IActionResult Index()
        {
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

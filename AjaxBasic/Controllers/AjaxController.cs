using AjaxBasic.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxBasic.Controllers
{
    public class AjaxController : Controller
    {
        NorthwindContext _context;
        public AjaxController(NorthwindContext context)
        {
            _context = context;
        }
        [HttpGet]
        public string Greet(string Name)
        {
            Thread.Sleep(3000);
            return $"{Name} 總統好!";
        }
        [HttpPost, ActionName("Greet")]
        public string PostGreet(string Name)
        {
            Thread.Sleep(3000);
            return $"{Name} 總統好!";
        }
        [HttpPost]
        public string FetchGreet([FromBody]Parameter p)
        {
            Thread.Sleep(3000);
            return $"{p.Name} 總統好!";
        }
        [HttpPost]
        public string CheckName(string FirstName)
        {
            Thread.Sleep(3000);
            bool Exists = _context.Employees.Any(e => e.FirstName == FirstName);
            return Exists ? "true" : "false" ;
        }
        [HttpPost]
        public string FetchCheckName([FromBody] Parameter p)
        {
            bool Exists = _context.Employees.Any(e => e.FirstName == p.Name);
            return Exists ? "true" : "false";
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

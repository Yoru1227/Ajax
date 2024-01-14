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
            return $"Hello, {Name}!";
        }
        [HttpPost, ActionName("Greet")]
        public string PostGreet(string Name)
        {
            return $"Hello, {Name}!";
        }
        [HttpPost]
        public string FetchPostGreet([FromBody]Parameter p)
        {
            return $"Hello, {p.Name}!";
        }
        [HttpPost]
        public string CheckName(string FirstName)
        {
            bool Exists = _context.Employees.Any(e => e.FirstName == FirstName);
            return Exists ? "true" : "false" ;
        }
        [HttpPost]
        public string CheckName([FromBody]Parameter p)
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

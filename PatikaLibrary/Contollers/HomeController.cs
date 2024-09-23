using Microsoft.AspNetCore.Mvc;

namespace PatikaLibrary.Contollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Info()
        {
            return View();
        }
        
    }
}

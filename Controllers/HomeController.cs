
using Microsoft.AspNetCore.Mvc;
namespace Scadenzario.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"]="Home Page".ToUpper();
            return View();
        }  
    }
}

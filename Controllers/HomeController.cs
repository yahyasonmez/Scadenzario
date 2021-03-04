
using Microsoft.AspNetCore.Mvc;
namespace Scadenzario.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Sono la Index del Controller Home.");
        }  
    }
}

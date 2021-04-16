
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Scadenzario.Controllers
{
     [Authorize]
    public class HomeController : Controller
    {
        [ResponseCache(CacheProfileName="Home")]
        public IActionResult Index()
        {
            ViewData["Title"]="Home Page".ToUpper();
            return View();
        }  
    }
}

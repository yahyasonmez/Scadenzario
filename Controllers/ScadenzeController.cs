using Microsoft.AspNetCore.Mvc;

namespace Scadenzario.Controllers
{
    public class ScadenzeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
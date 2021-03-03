using Microsoft.AspNetCore.Mvc;

namespace Scadenzario.Controllers
{
    public class ScadenzeController:Controller
    {
        public IActionResult Index()
        {
            return Content("Sono l'action Index");
        }
        public IActionResult Detail(int id)
        {
            return Content($"Sono l'action Detail, id passato {id}");
        }
    }
}
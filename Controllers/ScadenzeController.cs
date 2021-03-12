using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Scadenzario.Models.Services.Application;
using Scadenzario.Models.ViewModels;

namespace Scadenzario.Controllers
{
    public class ScadenzeController:Controller
    {
        public IActionResult Index()
        {
            var scadenzeService = new ScadenzeService();
            List<ScadenzeViewModel> scadenze = new();
            scadenze = scadenzeService.GetScadenze();
            return View(scadenze);
        }
        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
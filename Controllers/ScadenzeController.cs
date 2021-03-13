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
            ViewData["Title"]="Lista Scadenze";
            return View(scadenze);
        }
        public IActionResult Detail(int id)
        {
            var scadenzeService = new ScadenzeService();
            ScadenzeViewModel scadenze;
            scadenze = scadenzeService.GetScadenza(id);
            ViewData["Title"]="Dettaglio Scadenza "+ id.ToString();
            return View(scadenze);
        }
    }
}
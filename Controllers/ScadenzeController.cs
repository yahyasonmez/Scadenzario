using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Scadenzario.Models.Services.Application;
using Scadenzario.Models.ViewModels;

namespace Scadenzario.Controllers
{
    public class ScadenzeController : Controller
    {
        private readonly IScadenzeService service;
        public ScadenzeController(IScadenzeService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            List<ScadenzeViewModel> scadenze = new();
            scadenze = service.GetScadenze();
            ViewData["Title"] = "Lista Scadenze";
            return View(scadenze);
        }
        public IActionResult Detail(int id)
        {
            ScadenzeViewModel scadenze;
            scadenze = service.GetScadenza(id);
            ViewData["Title"] = "Dettaglio Scadenza " + id.ToString();
            return View(scadenze);
        }
    }
}
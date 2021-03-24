using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Scadenzario.Models.Entities;
using Scadenzario.Models.InputModels;
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
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Lista Scadenze".ToUpper();
            List<ScadenzaViewModel> viewModel = new();
            viewModel = await service.GetScadenzeAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> Detail(int id)
        {
            ViewData["Title"] = "Dettaglio Scadenza".ToUpper();
            ScadenzaViewModel viewModel;
            viewModel = await service.GetScadenzaAsync(id);
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Nuova Scadenza".ToUpper();
            ScadenzaCreateInputModel inputModel = new();
            inputModel.DataScadenza= DateTime.Now;
            inputModel.Beneficiari=service.GetBeneficiari;
            return View(inputModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ScadenzaCreateInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                await service.CreateScadenzaAsync(inputModel);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Title"] = "Nuova Scadenza".ToUpper();
                inputModel.Beneficiari=service.GetBeneficiari;
                return View(inputModel);
            }

        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Aggiorna Scadenza".ToUpper();
            ScadenzaEditInputModel inputModel = new();
            inputModel.Beneficiari=service.GetBeneficiari;
            inputModel = await service.GetScadenzaForEditingAsync(id);
            return View(inputModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ScadenzaEditInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                await service.EditScadenzaAsync(inputModel);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Title"] = "Aggiorna Scadenza".ToUpper();
                return View(inputModel);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            ScadenzaDeleteInputModel inputModel = new();
            inputModel.IDScadenza = id;

            if (ModelState.IsValid)
            {
                await service.DeleteScadenzaAsync(inputModel);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Title"] = "Elimina Scadenza".ToUpper();
                return View(inputModel);
            }

        }
    }
}
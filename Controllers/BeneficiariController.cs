using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scadenzario.Models.InputModels;
using Scadenzario.Models.Services.Application;
using Scadenzario.Models.ViewModels;

namespace Scadenzario.Controllers
{
    public class BeneficiariController : Controller
    {
        private readonly IBeneficiariService service;

        public async Task<IActionResult> IsBeneficiarioAvailable(string beneficiario)
        {
            bool result = await service.VerificationExistenceAsync(beneficiario);
            return Json(!result);
        }

        public BeneficiariController(IBeneficiariService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Lista Beneficiari".ToUpper();
            List<BeneficiarioViewModel> viewModel = new();
            viewModel = await service.GetBeneficiariAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> Detail(int id)
        {
            ViewData["Title"] = "Dettaglio Beneficiario".ToUpper();
            BeneficiarioViewModel viewModel;
            viewModel = await service.GetBeneficiarioAsync(id);
            viewModel.ToString();
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Nuovo beneficiario".ToUpper();
            BeneficiarioCreateInputModel inputModel = new();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BeneficiarioCreateInputModel inputModel)
        {
            if(ModelState.IsValid)
            {
                if(await service.VerificationExistenceAsync(inputModel.Beneficiario))
                {
                    ViewData["Title"] = "Nuovo beneficiario".ToUpper();
                    ModelState.AddModelError("key","Il beneficiario è già esistente. Scegli un nome diverso.");
                    return View(inputModel); 
                }
                await service.CreateBeneficiarioAsync(inputModel);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Title"] = "Nuovo beneficiario".ToUpper();
                return View(inputModel); 
            }
              
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Aggiorna Beneficiario".ToUpper();
            BeneficiarioEditInputModel inputModel = new();
            inputModel = await service.GetBeneficiarioForEditingAsync(id);
            return View(inputModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BeneficiarioEditInputModel inputModel)
        {
            if(ModelState.IsValid)
            {
                if(await service.VerificationExistenceAsync(inputModel.Beneficiario))
                {
                    ViewData["Title"] = "Aggiorna beneficiario".ToUpper();
                    ModelState.AddModelError("key","Il beneficiario è già esistente. Scegli un nome diverso.");
                    return View(inputModel); 
                }
                await service.EditBeneficiarioAsync(inputModel);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Title"] = "Aggiorna beneficiario".ToUpper();
                return View(inputModel); 
            }
              
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            BeneficiarioDeleteInputModel inputModel = new BeneficiarioDeleteInputModel();
            inputModel.IDBeneficiario=id;
            
            if(ModelState.IsValid)
            {
                await service.DeleteBeneficiarioAsync(inputModel);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Title"] = "Elimina beneficiario".ToUpper();
                return View(inputModel); 
            }
              
        }
    }
}
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
        public BeneficiariController(IBeneficiariService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            TempData["Title"] = "Nuovo beneficiario".ToUpper();
            BeneficiarioCreateInputModel inputModel = new();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BeneficiarioCreateInputModel inputModel)
        {
            inputModel = inputModel.Input;
            if(ModelState.IsValid)
            {
                await service.CreateBeneficiarioAsync(inputModel);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Title"] = "Nuovo beneficiario".ToUpper();
                return View(inputModel); 
            }
              
        }
    }
}
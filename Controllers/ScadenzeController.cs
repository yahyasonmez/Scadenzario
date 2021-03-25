using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IWebHostEnvironment environment;
        public ScadenzeController(IScadenzeService service, IWebHostEnvironment environment)
        {
            this.environment = environment;
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
            inputModel.DataScadenza = DateTime.Now;
            inputModel.Beneficiari = service.GetBeneficiari;
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
                inputModel.Beneficiari = service.GetBeneficiari;
                return View(inputModel);
            }

        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Aggiorna Scadenza".ToUpper();
            ScadenzaEditInputModel inputModel = new();
            inputModel = await service.GetScadenzaForEditingAsync(id);
            inputModel.Beneficiari = service.GetBeneficiari;
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
                inputModel.Beneficiari = service.GetBeneficiari;
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
        [HttpPost]
        public ActionResult FileUpload()
		{
            var files = Request.Form.Files;
            var i = 0;
			foreach (var file in files)
            {
				var filename = ContentDispositionHeaderValue
								.Parse(file.ContentDisposition)
								.FileName
								.Trim('"');
				var webRoot = environment.WebRootPath;
				var path = webRoot + "/Upload";
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);
                filename = System.IO.Path.Combine(path, filename);
				using (FileStream fs = System.IO.File.Create(filename))
				{
					file.CopyTo(fs);
					fs.Flush();
				}
                i += 1;
			}
			string message = "Upload effettuato correttamente!";
			JsonResult result = new JsonResult(message);
			return result;
		}    
        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
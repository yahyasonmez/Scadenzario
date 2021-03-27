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
using Models.Utility;
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
        private readonly IRicevuteService ricevute;

        public static List<RicevutaCreateInputModel> Ricevute { get; private set;}
        public ScadenzeController(IScadenzeService service, IRicevuteService ricevute, IWebHostEnvironment environment)
        {
            this.ricevute = ricevute;
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
            if(id==0)
              id = Convert.ToInt32(TempData["id"]);
            ViewData["Title"] = "Dettaglio Scadenza".ToUpper();
            ScadenzaViewModel viewModel;
            viewModel = await service.GetScadenzaAsync(id);
            viewModel.Ricevute = ricevute.GetRicevute(id);
            TempData["id"]=id;
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
            inputModel.Beneficiario=service.GetBeneficiarioById(inputModel.IDBeneficiario);
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
            if(id==0)
              id = Convert.ToInt32(TempData["id"]);
            TempData["IDScadenza"]=id; 
            ViewData["Title"] = "Aggiorna Scadenza".ToUpper();
            ScadenzaEditInputModel inputModel = new();
            inputModel = await service.GetScadenzaForEditingAsync(id);
            inputModel.Beneficiari = service.GetBeneficiari;
            TempData["id"]=id;
            inputModel.Beneficiario=service.GetBeneficiarioById(inputModel.IDBeneficiario);
            return View(inputModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ScadenzaEditInputModel inputModel)
        {
            inputModel.Beneficiario=service.GetBeneficiarioById(inputModel.IDBeneficiario);
            if (ModelState.IsValid)
            {
                await service.EditScadenzaAsync(inputModel);
                //Gestione Ricevute
                if(Ricevute!=null)
                    await ricevute.CreateRicevutaAsync(Ricevute);
                Ricevute=null;
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
        public async Task<IActionResult> FileUpload()
        {
            var id = Convert.ToInt32(TempData["IDScadenza"]);
            ScadenzaEditInputModel inputModel = new();
            inputModel = await service.GetScadenzaForEditingAsync(id);
            var files = Request.Form.Files;
            var i = 0;
            var webRoot = environment.WebRootPath;
            var path = webRoot + "\\Upload";
            foreach (var file in files)
            {
                RicevutaCreateInputModel ricevuta = new RicevutaCreateInputModel();
                var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                ricevuta.FileName=filename;
                var fileType = file.ContentType;
                var fileLenght = file.Length;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                filename = System.IO.Path.Combine(path, filename);
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    await file.CopyToAsync(fs);
                    await fs.FlushAsync();
                }
                i += 1;
                ricevuta.FileType=fileType;
                ricevuta.Path=filename;
                ricevuta.IDScadenza=inputModel.IDScadenza;
                ricevuta.Beneficiario=inputModel.Beneficiario;
                byte[] filedata = new byte[fileLenght];
                using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
				{
					using (var reader = new BinaryReader(stream))
					{
						filedata = reader.ReadBytes((int)stream.Length);
					}
				} 
                ricevuta.FileContent=filedata;
                AddRicevuta(ricevuta);
            }
            string message = "Upload effettuato correttamente!";
            JsonResult result = new JsonResult(message);
            return result;
        }
        public static void AddRicevuta(RicevutaCreateInputModel ricevuta)
        {
            if(Ricevute==null)
               Ricevute = new();
            Ricevute.Add(ricevuta);
        }
        public async Task<IActionResult> Download(int Id)
        {
            var viewModel = await ricevute.GetRicevutaAsync(Id);
            string filename = viewModel.Path;
            if (filename == null)
                throw new Exception("File name not found");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, Utility.GetContentType(path), Path.GetFileName(path));
        }
        public async Task<IActionResult> DeleteAllegato(int id, int idscadenza)
        {
            ScadenzaViewModel viewModel = await service.GetScadenzaAsync(idscadenza);
            ViewData["Title"] = "Dettaglio Scadenza".ToUpper();
            RicevutaViewModel ricevutaViewModel = await ricevute.GetRicevutaAsync(id);
            await ricevute.DeleteRicevutaAsync(id);
            System.IO.File.Delete(ricevutaViewModel.Path);
            viewModel.Ricevute = ricevute.GetRicevute(idscadenza);
            return View("Detail",viewModel);
        }
        
    }
}
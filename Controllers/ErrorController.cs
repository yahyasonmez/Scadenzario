using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Scadenzario.Controllers
{
    public class ErrorController:Controller
    {
        public IActionResult Index()
        {
            var features = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            switch(features.Error)
            {
                case ScadenzaNotFoundException exc:
                    ViewData["Title"] = "Scadenza non trovata";
                    Response.StatusCode = 404;
                    return View("ScadenzaNotFound");

                case BeneficiarioNotFoundException exc:
                    ViewData["Title"] = "Beneficiario non trovato";
                    Response.StatusCode = 404;
                    return View("BeneficiarioNotFound");  

                 case RicevutaNotFoundException exc:
                    ViewData["Title"] = "Ricevuta non trovata";
                    Response.StatusCode = 404;
                    return View("RicevutaNotFound");        

                case UserUnknownException exc:
                    ViewData["Title"] = "Utente sconosciuto";
                    Response.StatusCode = 400;
                    return View();

                default:
                    ViewData["Title"] = "Errore";
                    return View();
            }
            
        } 
    }
}
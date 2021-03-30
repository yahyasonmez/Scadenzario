using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Scadenzario.Models.Entities;
using Scadenzario.Models.Services.Infrastructure;

namespace Scadenzario.Models.InputModels
{
    public class ScadenzaCreateInputModel
    {
        [Required(ErrorMessage="Il Beneficiario è obbligatorio."),
        Display(Name = "Beneficiario")]
        public int IDBeneficiario { get; set; }
        public string Beneficiario { get; set; }
        [Required (ErrorMessage="La Data Scadenza è obbligatoria."),
        DataType(DataType.Date, ErrorMessage="Formato data non valido."),
        Display(Name = "Data Scadenza")]
        public DateTime DataScadenza { get; set; }
        [Required (ErrorMessage="L'importo è obbligatorio.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:n}", ApplyFormatInEditMode = true)]
        public Decimal Importo { get; set; }
        public List<SelectListItem> Beneficiari{get;set;}
    }
}
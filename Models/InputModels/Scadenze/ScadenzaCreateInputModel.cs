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
        [Required]
        [Display(Name = "Beneficiario")]
        public int IDBeneficiario { get; set; }
        public string Beneficiario { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data Scadenza")]
        public DateTime DataScadenza { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public Decimal Importo { get; set; }
        public List<SelectListItem> Beneficiari{get;set;}
    }
}
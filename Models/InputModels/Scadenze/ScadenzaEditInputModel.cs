using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Scadenzario.Models.Entities;

namespace Scadenzario.Models.ViewModels
{
    public class ScadenzaEditInputModel
    {
        [Required]
		public int IDScadenza { get; set; }
        public String IdUser { get; set; }
        public int IDBeneficiario { get; set; }
        [Required]
		public String Beneficiario { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataScadenza { get; set; }
        [Required]
         [DataType(DataType.Currency)]
		public decimal Importo { get; set; }
		public bool Sollecito { get; set; }
		public short? GiorniRitardo { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataPagamento { get; set; }
        public List<SelectListItem> Beneficiari{get;set;}
        public static ScadenzaEditInputModel FromEntity(Scadenza scadenza)
        {
            return new ScadenzaEditInputModel {
                IDScadenza = scadenza.IDScadenza,
                Beneficiario = scadenza.Beneficiario,
                IdUser = scadenza.IDUser,
                IDBeneficiario = scadenza.IDBeneficiario,
                DataScadenza = scadenza.DataScadenza,
                Importo = scadenza.Importo,
                Sollecito=scadenza.Sollecito,
                GiorniRitardo=scadenza.GiorniRitardo,
                DataPagamento=scadenza.DataPagamento
            };
        }
    }
}
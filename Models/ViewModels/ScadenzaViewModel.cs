using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Scadenzario.Models.Entities;
using Scadenzario.Models.Services.Infrastructure;

namespace Scadenzario.Models.ViewModels
{
    public class ScadenzaViewModel
    {
        public int IDScadenza { get; set; }
        public String IdUser { get; set; }
        public int IDBeneficiario { get; set; }
        public String Beneficiario { get; set; }
        [Display(Name = "Data Scadenza")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataScadenza { get; set; }
        [Display(Name = "Importo Euro")]
		[DisplayFormat(DataFormatString = "{0:n} €")]
        public decimal Importo { get; set; }
        public bool Sollecito { get; set; }
        [Display(Name = "Giorni Ritardo")]
        public int? GiorniRitardo { get; set; }
        [Display(Name = "Data Pagamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataPagamento { get; set; }
        public static ScadenzaViewModel FromEntity(Scadenza scadenza)
        {
            return new ScadenzaViewModel
            {
                IDScadenza = scadenza.IDScadenza,
                Beneficiario = scadenza.Beneficiario,
                IdUser = scadenza.IDUser,
                IDBeneficiario = scadenza.IDBeneficiario,
                DataScadenza = scadenza.DataScadenza,
                Importo = scadenza.Importo,
                Sollecito = scadenza.Sollecito,
                GiorniRitardo = scadenza.GiorniRitardo,
                DataPagamento = scadenza.DataPagamento
            };
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using Scadenzario.Models.Entities;

namespace Scadenzario.Models.ViewModels
{
    public class ScadenzaViewModel
    {
		public int IDScadenza { get; set; }
        public String IdUser { get; set; }
        public int IDBeneficiario { get; set; }
		public String Beneficiario { get; set; }
        public DateTime DataScadenza { get; set; }
		public decimal Importo { get; set; }
		public bool Sollecito { get; set; }
		public int? GiorniRitardo { get; set; }
        public DateTime? DataPagamento { get; set; }
        public static ScadenzaViewModel FromEntity(Scadenza scadenza)
        {
            return new ScadenzaViewModel {
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
using System;
using System.ComponentModel.DataAnnotations;
namespace Scadenzario.Models.ViewModels
{
    public class ScadenzeViewModel
    {
		public int IDScadenza { get; set; }
        public String IdUser { get; set; }
        public String IDBeneficiario { get; set; }
		public String Beneficiario { get; set; }
        public DateTime DataScadenza { get; set; }
		public decimal Importo { get; set; }
		public bool Sollecito { get; set; }
		public int? GiorniRitardo { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
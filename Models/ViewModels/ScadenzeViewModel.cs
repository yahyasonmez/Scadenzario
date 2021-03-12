using System;

namespace Scadenzario.Models.ViewModels
{
    public class ScadenzeViewModel
    {
		public int IDScadenza { get; set; }
        public String IdUser { get; set; }
		public String Beneficiario { get; set; }
        public DateTime DataScadenza { get; set; }
		public Decimal Importo { get; set; }
		public bool Sollecito { get; set; }
		public int? GiorniRitardo { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
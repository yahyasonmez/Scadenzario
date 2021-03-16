using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
public class Scadenze
	{
		public int IDScadenza { get; set; }
        public String IDUser { get; set; }
        public String IDBeneficiario { get; set; }
		public String Beneficiario { get; set; }
		public DateTime DataScadenza { get; set; }
		public decimal Importo { get; set; }
		public bool Sollecito { get; set; }
		public int? GiorniRitardo { get; set; }
        public DateTime? DataPagamento { get; set; }

    }
}
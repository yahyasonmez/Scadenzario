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
		[Display(Name = "Data Scadenza")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataScadenza { get; set; }
		[Display(Name = "Importo Euro")]
		[DisplayFormat(DataFormatString = "{0:n} €")]
		[Required(ErrorMessage = "Importo Obbligatorio")]
		public decimal Importo { get; set; }
        [Display(Name = "Sollecito")]
		public bool Sollecito { get; set; }
		[Display(Name = "Ritardo Giorni")]
		public int? GiorniRitardo { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data Pagamento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataPagamento { get; set; }
    }
}
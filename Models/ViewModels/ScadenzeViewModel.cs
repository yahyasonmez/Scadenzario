using System;
using System.ComponentModel.DataAnnotations;
namespace Scadenzario.Models.ViewModels
{
    public class ScadenzeViewModel
    {
		public int IDScadenza { get; set; }
        public String IdUser { get; set; }
		public String Beneficiario { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data Scadenza")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataScadenza { get; set; }
		public Decimal Importo { get; set; }
		public bool Sollecito { get; set; }
		public int? GiorniRitardo { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data Pagamento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataPagamento { get; set; }
    }
}
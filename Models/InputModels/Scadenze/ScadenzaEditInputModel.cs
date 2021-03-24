using System;
using System.ComponentModel.DataAnnotations;
using Scadenzario.Models.Entities;

namespace Scadenzario.Models.ViewModels
{
    public class ScadenzaEditInputModel
    {
        [Required]
		public int IDScadenza { get; set; }
        [Required]
        public String IdUser { get; set; }
        [Required]
        public int IDBeneficiario { get; set; }
        [Required]
		public String Beneficiario { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataScadenza { get; set; }
        [Required]
         [DataType(DataType.Currency)]
		public decimal Importo { get; set; }
		public bool Sollecito { get; set; }
		public short? GiorniRitardo { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DataPagamento { get; set; }
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
using System;
using System.ComponentModel.DataAnnotations;
namespace Scadenzario.Models.InputModels
{
    public class ScadenzaCreateInputModel
    {
        [Required]
        public string Beneficiario { get; set; }
        [Required]
        public DateTime DataScadenza { get; set; }
         [Required]
        public Decimal Importo { get; set; }
    }
}
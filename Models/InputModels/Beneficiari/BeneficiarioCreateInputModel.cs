using System;
using System.ComponentModel.DataAnnotations;
namespace Scadenzario.Models.InputModels
{
    public class BeneficiarioCreateInputModel
    {
        [Required]
        public string Beneficiario { get; set; }
        [Required]
        public string Descrizione { get; set; }
    }
}
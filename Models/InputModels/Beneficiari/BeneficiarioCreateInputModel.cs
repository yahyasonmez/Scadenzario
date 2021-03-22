using System;
using System.ComponentModel.DataAnnotations;
namespace Scadenzario.Models.InputModels
{
    public class BeneficiarioCreateInputModel
    {
        public BeneficiarioCreateInputModel Input { get; set; }
		public int IDBeneficiario { get; set; }
        [Required]
        public string Beneficiario { get; set; }
        [Required]
        public string Descrizione { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
         [DataType(DataType.Url)]
        public string SitoWeb { get; set; }
    }
}
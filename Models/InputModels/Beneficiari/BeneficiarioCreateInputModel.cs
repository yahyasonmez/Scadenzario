using System;
using System.ComponentModel.DataAnnotations;
namespace Scadenzario.Models.InputModels
{
    public class BeneficiarioCreateInputModel
    {
        public BeneficiarioCreateInputModel Input { get; set; }
		public int IDBeneficiario { get; set; }
        public string Beneficiario { get; set; }
        public string Descrizione { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string SitoWeb { get; set; }
    }
}
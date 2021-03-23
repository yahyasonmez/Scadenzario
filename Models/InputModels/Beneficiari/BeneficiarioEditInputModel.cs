using System;
using System.ComponentModel.DataAnnotations;
using Scadenzario.Models.Entities;

namespace Scadenzario.Models.InputModels
{
    public class BeneficiarioEditInputModel
    {
        [Required]
        public int IDBeneficiario {get;set;}
        [Required]
        public string Beneficiario { get; set; }
        [Required]
        public string Descrizione { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string SitoWeb { get; set; }

        public static BeneficiarioEditInputModel FromEntity(Beneficiario beneficiario)
        {
            return new BeneficiarioEditInputModel {
                IDBeneficiario = beneficiario.IDBeneficiario,
                Descrizione = beneficiario.Descrizione,
                Beneficiario = beneficiario.Sbeneficiario,
                Email = beneficiario.Email,
                Telefono = beneficiario.Telefono,
                SitoWeb = beneficiario.SitoWeb  
            };
        }
    }
    
}
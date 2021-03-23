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
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [DataType(DataType.Url)]
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
using System;
using System.ComponentModel.DataAnnotations;
using Scadenzario.Models.Entities;

namespace Scadenzario.Models.ViewModels
{
    public class BeneficiarioViewModel
    {
		public int IDBeneficiario { get; set; }
        public string Beneficiario { get; set; }
        public string Descrizione { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string SitoWeb { get; set; }

        public static BeneficiarioViewModel FromEntity(Beneficiario beneficiario)
        {
            return new BeneficiarioViewModel {
                IDBeneficiario = beneficiario.IDBeneficiario,
                Beneficiario = beneficiario.Sbeneficiario,
                Descrizione = beneficiario.Descrizione,
                Email = beneficiario.Email,
                Telefono = beneficiario.Telefono,
                SitoWeb = beneficiario.SitoWeb
            };
        }
    }
}
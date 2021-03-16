using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Beneficiari
	{
		public int IDBeneficiario { get; set; }
		public String Beneficiario { get; set; }
		public String Descrizione { get; set; }
        public String Email { get; set; }
        public String Telefono { get; set; }
        public String SitoWeb { get; set; }
	}
}
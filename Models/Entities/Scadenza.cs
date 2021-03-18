using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace Scadenzario.Models.Entities
{
    public partial class Scadenza
    {
        public Scadenza()
        {
            Ricevute = new HashSet<Ricevuta>();
        }

        public int IDScadenza { get; set; }
        public String IDUser { get; set; }
        public int IDBeneficiario { get; set; }
        public string Beneficiario { get; set; }
        public DateTime DataScadenza { get; set; }
        public decimal Importo { get; set; }
        public bool Sollecito { get; set; }
        public short? GiorniRitardo { get; set; }
        public DateTime? DataPagamento { get; set; }

        public virtual Beneficiario beneficiario { get; set; }
        public virtual ICollection<Ricevuta> Ricevute { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    
}

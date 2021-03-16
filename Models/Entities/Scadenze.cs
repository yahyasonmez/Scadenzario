using System;
using System.Collections.Generic;

#nullable disable

namespace Scadenzario.Models.Entities
{
    public partial class Scadenze
    {
        public Scadenze()
        {
            Ricevutes = new HashSet<Ricevute>();
        }

        public int Idscadenza { get; set; }
        public int Iduser { get; set; }
        public int Idbeneficiario { get; set; }
        public string Beneficiario { get; set; }
        public DateTime DataScadenza { get; set; }
        public decimal Importo { get; set; }
        public bool Sollecito { get; set; }
        public short? GiorniRitardo { get; set; }
        public DateTime? DataPagamento { get; set; }

        public virtual Beneficiari IdbeneficiarioNavigation { get; set; }
        public virtual ICollection<Ricevute> Ricevutes { get; set; }
    }
}

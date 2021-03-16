using System;
using System.Collections.Generic;

#nullable disable

namespace Scadenzario.Models.Entities
{
    public partial class Beneficiari
    {
        public Beneficiari()
        {
            Scadenze = new HashSet<Scadenze>();
        }

        public int Idbeneficiario { get; set; }
        public string Beneficiario { get; set; }
        public string Descrizione { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string SitoWeb { get; set; }

        public virtual ICollection<Scadenze> Scadenze { get; set; }
    }
}

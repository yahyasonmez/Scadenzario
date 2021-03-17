using System;
using System.Collections.Generic;

#nullable disable

namespace Scadenzario.Models.Entities
{
    public partial class Ricevuta
    {
        public int Id { get; set; }
        public int IDScadenza { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileContent { get; set; }
        public string Beneficiario { get; set; }

        public virtual Scadenza Scadenza { get; set; }
    }
}

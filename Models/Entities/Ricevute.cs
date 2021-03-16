using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Ricevute
	{
		public int Id { get; set; }
		public int IDScadenza { get; set; }
		public string FileName { get; set; }
		public string FileType { get; set; }
		public byte[] FileContent { get; set; }
		public String Beneficiario { get; set; }

	}
}
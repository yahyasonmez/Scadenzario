using System;
using System.ComponentModel.DataAnnotations;
namespace Scadenzario.Models.InputModels
{
    public class ScadenzaDeleteInputModel
    {
        [Required]
        public int IDScadenza { get; set; }
    }
}
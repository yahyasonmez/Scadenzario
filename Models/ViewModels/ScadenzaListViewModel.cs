using System.Collections.Generic;
using Scadenzario.Models.InputModels.Scadenze;

namespace Scadenzario.Models.ViewModels
{
    public class ScadenzaListViewModel
    {
        public List<ScadenzaViewModel> Scadenze {get;set;}
        public ScadenzaListInputModel Input {get;set;}
    }
}
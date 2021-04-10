using System.Collections.Generic;
using Scadenzario.Models.InputModels.Beneficiari;

namespace Scadenzario.Models.ViewModels
{
    public class BeneficiarioListViewModel
    {
        public ListViewModel<BeneficiarioViewModel> Beneficiari {get;set;}
        public BeneficiarioListInputModel Input {get;set;}
    }
}
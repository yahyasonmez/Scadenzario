using System.Collections.Generic;
using Scadenzario.Models.InputModels.Beneficiari;
using Scadenzario.Models.InputModels.Scadenze;

namespace Scadenzario.Models.ViewModels
{
    public class BeneficiarioListViewModel
    {
        public List<BeneficiarioViewModel> Beneficiari {get;set;}
        public BeneficiarioListInputModel Input {get;set;}
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Scadenzario.Models.InputModels;
using Scadenzario.Models.ViewModels;

namespace Scadenzario.Models.Services.Application
{
    public interface IBeneficiariService
    {
        List<BeneficiarioDetailViewModel> GetBeneficiari();
        Task<BeneficiarioDetailViewModel> CreateBeneficiarioAsync(BeneficiarioCreateInputModel inputModel);
    }
}
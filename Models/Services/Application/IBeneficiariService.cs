using System.Collections.Generic;
using System.Threading.Tasks;
using Scadenzario.Models.InputModels;
using Scadenzario.Models.ViewModels;

namespace Scadenzario.Models.Services.Application
{
    public interface IBeneficiariService
    {
        Task<List<BeneficiarioViewModel>> GetBeneficiariAsync();
        Task<BeneficiarioViewModel> CreateBeneficiarioAsync(BeneficiarioCreateInputModel inputModel);
        Task<BeneficiarioViewModel> GetBeneficiarioAsync(int id);
    }
}
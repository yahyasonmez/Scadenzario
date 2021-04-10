using System.Collections.Generic;
using System.Threading.Tasks;
using Scadenzario.Models.InputModels;
using Scadenzario.Models.InputModels.Beneficiari;
using Scadenzario.Models.ViewModels;

namespace Scadenzario.Models.Services.Application.Beneficiari
{
    public interface IBeneficiariService
    {
        Task<ListViewModel<BeneficiarioViewModel>> GetBeneficiariAsync(BeneficiarioListInputModel model);
        Task<BeneficiarioViewModel> CreateBeneficiarioAsync(BeneficiarioCreateInputModel inputModel);
        Task<BeneficiarioViewModel> GetBeneficiarioAsync(int id);
        Task DeleteBeneficiarioAsync(BeneficiarioDeleteInputModel inputModel);
        Task<BeneficiarioEditInputModel> GetBeneficiarioForEditingAsync(int id);
        Task<BeneficiarioViewModel> EditBeneficiarioAsync(BeneficiarioEditInputModel inputModel);
        Task<bool> VerificationExistenceAsync(string beneficiario);
    }
}
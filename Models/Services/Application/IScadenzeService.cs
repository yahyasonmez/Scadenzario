using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Scadenzario.Models.InputModels;
using Scadenzario.Models.ViewModels;

namespace Scadenzario.Models.Services.Application
{
    public interface IScadenzeService
    {
        Task<List<ScadenzaViewModel>> GetScadenzeAsync();
        Task<ScadenzaViewModel> CreateScadenzaAsync(ScadenzaCreateInputModel inputModel);
        Task<ScadenzaViewModel> GetScadenzaAsync(int id);
        Task DeleteScadenzaAsync(ScadenzaDeleteInputModel inputModel);
        Task<ScadenzaEditInputModel> GetScadenzaForEditingAsync(int id);
        Task<ScadenzaViewModel> EditScadenzaAsync(ScadenzaEditInputModel inputModel);
        List<SelectListItem> GetBeneficiari{get;}
    }
}
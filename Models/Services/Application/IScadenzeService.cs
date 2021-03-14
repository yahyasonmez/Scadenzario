using System.Collections.Generic;
using Scadenzario.Models.ViewModels;

namespace Scadenzario.Models.Services.Application
{
    public interface IScadenzeService
    {
         List<ScadenzeViewModel> GetScadenze();
         ScadenzeViewModel GetScadenza(int id);
    }
}
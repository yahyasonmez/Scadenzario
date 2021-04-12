using Microsoft.AspNetCore.Mvc;
using Scadenzario.Models.ViewModels;
using System.Collections.Generic;

namespace Scadenzario.Customizations.ViewComponents
{
    public class PaginationBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IPaginationInfo model)
        {
            //Il numero di pagina corrente
            //Il numero di risultati totali
            //Il numero di risultati per pagina
            return View(model);
        }
    }
}
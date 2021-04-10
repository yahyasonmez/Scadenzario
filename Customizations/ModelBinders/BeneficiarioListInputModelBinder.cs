using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Scadenzario.Models.InputModels;
using Scadenzario.Models.InputModels.Beneficiari;
using Scadenzario.Models.Options;

namespace Scadenzario.Customizations.ModelBinders
{
    public class BeneficiarioListInputModelBinder : IModelBinder
    {
        private readonly IOptionsMonitor<BeneficiariOptions> coursesOptions;
        public BeneficiarioListInputModelBinder(IOptionsMonitor<BeneficiariOptions> coursesOptions)
        {
            this.coursesOptions = coursesOptions;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //Recuperiamo i valori grazie ai value provider
            string search = bindingContext.ValueProvider.GetValue("Search").FirstValue;
            string orderBy = bindingContext.ValueProvider.GetValue("OrderBy").FirstValue;
            int.TryParse(bindingContext.ValueProvider.GetValue("Page").FirstValue, out int page);
            bool.TryParse(bindingContext.ValueProvider.GetValue("Ascending").FirstValue, out bool ascending);

            //Creiamo l'istanza del CourseListInputModel
            BeneficiariOptions options = coursesOptions.CurrentValue;
            var inputModel = new BeneficiarioListInputModel(search, page, orderBy, ascending, options.PerPage, options.Order);

            //Impostiamo il risultato per notificare che la creazione è avvenuta con successo
            bindingContext.Result = ModelBindingResult.Success(inputModel);

            //Restituiamo un task completato
            return Task.CompletedTask;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Scadenzario.Models.Entities;
using Scadenzario.Models.InputModels;
using Scadenzario.Models.Services.Infrastructure;
using Scadenzario.Models.ViewModels;

namespace Scadenzario.Models.Services.Application.Scadenze
{
    public class MemoryCacheScadenzaService : ICachedScadenzaService
    {
        private readonly IScadenzeService scadenzaService;
        private readonly IMemoryCache memoryCache;
        private readonly MyScadenzaDbContext dbContext;
        public MemoryCacheScadenzaService(MyScadenzaDbContext dbContext, IScadenzeService scadenzaService, IMemoryCache memoryCache)
        {
            this.dbContext = dbContext;
            this.scadenzaService = scadenzaService;
            this.memoryCache = memoryCache;
        }

        public Task<List<ScadenzaViewModel>> GetScadenzeAsync()
        {
            return scadenzaService.GetScadenzeAsync();
        }
        public Task<ScadenzaViewModel> GetScadenzaAsync(int id)
        {
            /*--Andiamo a cercare in memoria un oggetto identificato dalla chiave Scadenza + id
            e se non dovesse esistere lo recuperiamo dal database impostando 60 secondi*/
            return memoryCache.GetOrCreateAsync($"Scadenze{id}", cacheEntry =>
            {
                cacheEntry.SetSize(1);
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(60));
                return scadenzaService.GetScadenzaAsync(id);
            });
        }

        public Task<ScadenzaViewModel> CreateScadenzaAsync(ScadenzaCreateInputModel inputModel)
        {
            return scadenzaService.CreateScadenzaAsync(inputModel);
        }

        public Task<ScadenzaEditInputModel> GetScadenzaForEditingAsync(int id)
        {
            return scadenzaService.GetScadenzaForEditingAsync(id);
        }
        public async Task<ScadenzaViewModel> EditScadenzaAsync(ScadenzaEditInputModel inputModel)
        {
            ScadenzaViewModel viewModel = await scadenzaService.EditScadenzaAsync(inputModel);
            memoryCache.Remove($"Scadenze{inputModel.IDScadenza}");
            return viewModel;
        }

        public async Task DeleteScadenzaAsync(ScadenzaDeleteInputModel inputModel)
        {
            await scadenzaService.DeleteScadenzaAsync(inputModel);
            memoryCache.Remove($"Scadenze{inputModel.IDScadenza}");
        }
        public List<SelectListItem> GetBeneficiari
        {
            get
            {
                List<Beneficiario> beneficiari = new List<Beneficiario>();
                beneficiari = (from b in dbContext.Beneficiari
                               select b).ToList();

                var beneficiario = beneficiari.Select(b => new SelectListItem
                {
                    Text = b.Sbeneficiario,
                    Value = b.IDBeneficiario.ToString()
                }).ToList();
                return beneficiario;
            }
        }
        //Recupero Beneficiario
        public string GetBeneficiarioById(int id)
        {
            string Beneficiario = dbContext.Beneficiari
            .Where(t => t.IDBeneficiario == id)
            .Select(t => t.Sbeneficiario).Single();
            return Beneficiario;
        }
        //Calcolo giorni ritardo o giorni mancanti al pagamento
        public int DateDiff(DateTime inizio, DateTime fine)
        {
            int giorni = 0;
            giorni = (inizio.Date - fine.Date).Days;
            return giorni;
        }
    }
}
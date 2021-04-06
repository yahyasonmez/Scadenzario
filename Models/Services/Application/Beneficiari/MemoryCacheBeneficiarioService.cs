using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Scadenzario.Models.Entities;
using Scadenzario.Models.InputModels;
using Scadenzario.Models.Services.Infrastructure;
using Scadenzario.Models.ViewModels;

namespace Scadenzario.Models.Services.Application.Beneficiari
{
    public class MemoryCacheBeneficiarioService:ICachedBeneficiarioService
    {
        private readonly IBeneficiariService beneficiarioService;
        private readonly IMemoryCache memoryCache;
        private readonly MyScadenzaDbContext dbContext;
        public MemoryCacheBeneficiarioService(MyScadenzaDbContext dbContext, IBeneficiariService beneficiarioService, IMemoryCache memoryCache)
        {
            this.dbContext = dbContext;
            this.beneficiarioService = beneficiarioService;
            this.memoryCache = memoryCache;
        }

        public Task<List<BeneficiarioViewModel>> GetBeneficiariAsync()
        {
            /*--Andiamo a cercare in memoria un oggetto identificato dalla chiave Beneficiari
            e se non dovesse esistere lo recuperiamo dal database impostando 60 secondi*/
            return memoryCache.GetOrCreateAsync($"Beneficiari", cacheEntry =>
            {
                cacheEntry.SetSize(1);
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(60)); //Esercizio: provate a recuperare il valore 60 usando il servizio di configurazione
                return beneficiarioService.GetBeneficiariAsync();
            });
        }
        public Task<BeneficiarioViewModel> GetBeneficiarioAsync(int id)
        {
            /*--Andiamo a cercare in memoria un oggetto identificato dalla chiave Beneficiario + id
            e se non dovesse esistere lo recuperiamo dal database impostando 60 secondi*/
            return memoryCache.GetOrCreateAsync($"Beneficiario{id}", cacheEntry =>
            {
                cacheEntry.SetSize(1);
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromSeconds(60));
                return beneficiarioService.GetBeneficiarioAsync(id);
            });
        }

        public Task<BeneficiarioViewModel> CreateBeneficiarioAsync(BeneficiarioCreateInputModel inputModel)
        {
            return beneficiarioService.CreateBeneficiarioAsync(inputModel);
        }

        public Task<BeneficiarioEditInputModel> GetBeneficiarioForEditingAsync(int id)
        {
            return beneficiarioService.GetBeneficiarioForEditingAsync(id);
        }
        public async Task<BeneficiarioViewModel> EditBeneficiarioAsync(BeneficiarioEditInputModel inputModel)
        {
            BeneficiarioViewModel viewModel = await beneficiarioService.EditBeneficiarioAsync(inputModel);
            memoryCache.Remove($"Beneficiario{inputModel.IDBeneficiario}");
            return viewModel;
        }

        public async Task DeleteBeneficiarioAsync(BeneficiarioDeleteInputModel inputModel)
        {
            await beneficiarioService.DeleteBeneficiarioAsync(inputModel);
            memoryCache.Remove($"Beneficiario{inputModel.IDBeneficiario}");
        }

        public async Task<bool> VerificationExistenceAsync(string beneficiario)
        {
           Beneficiario verify = await dbContext.Beneficiari.FirstOrDefaultAsync(b=>b.Sbeneficiario==beneficiario);
            if(verify==null)
               return false;
            return true;  
        }
    }
}
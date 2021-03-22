using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Scadenzario.Models.Entities;
using Scadenzario.Models.InputModels;
using Scadenzario.Models.Services.Application;
using Scadenzario.Models.Services.Infrastructure;
using Scadenzario.Models.ViewModels;

namespace Scadenzario.Models.Services.Application
{
    public class EFCoreBeneficiarioService:IBeneficiariService
    {
        private readonly ILogger<EFCoreBeneficiarioService> logger;
        private readonly MyScadenzaDbContext dbContext;
        public EFCoreBeneficiarioService(ILogger<EFCoreBeneficiarioService> logger, MyScadenzaDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.logger = logger;

        }
        public async Task<BeneficiarioDetailViewModel> CreateBeneficiarioAsync(BeneficiarioCreateInputModel inputModel)
        {
            Beneficiario beneficiario = new Beneficiario();
            beneficiario.Sbeneficiario = inputModel.Beneficiario;
            beneficiario.Descrizione = inputModel.Descrizione;
            beneficiario.Email = inputModel.Email;
            beneficiario.Telefono = inputModel.Telefono;
            beneficiario.SitoWeb = inputModel.SitoWeb;
            await dbContext.AddAsync(beneficiario);
            await dbContext.SaveChangesAsync();
            return BeneficiarioDetailViewModel.FromEntity(beneficiario);
        }

        public List<BeneficiarioDetailViewModel> GetBeneficiari()
        {
            throw new NotImplementedException();
        }
    }
}
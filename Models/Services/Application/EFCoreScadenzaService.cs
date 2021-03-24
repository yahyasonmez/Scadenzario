using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Scadenzario.Models.Entities;
using Scadenzario.Models.Exceptions.Application;
using Scadenzario.Models.InputModels;
using Scadenzario.Models.Services.Application;
using Scadenzario.Models.Services.Infrastructure;
using Scadenzario.Models.ViewModels;

namespace Scadenzario.Models.Services.Application
{
    public class EFCoreScadenzaService:IScadenzeService
    {
        private readonly ILogger<EFCoreBeneficiarioService> logger;
        private readonly MyScadenzaDbContext dbContext;
        public EFCoreScadenzaService(ILogger<EFCoreBeneficiarioService> logger, MyScadenzaDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.logger = logger;

        }
        public async Task<ScadenzaViewModel> CreateScadenzaAsync(ScadenzaCreateInputModel inputModel)
        {
            Scadenza scadenza = new ();
            scadenza.Beneficiario = inputModel.Beneficiario;
            scadenza.DataScadenza = inputModel.DataScadenza;
            scadenza.Importo = inputModel.Importo;
            await dbContext.AddAsync(scadenza);
            await dbContext.SaveChangesAsync();
            return ScadenzaViewModel.FromEntity(scadenza);
        }

        public async Task<List<ScadenzaViewModel>> GetScadenzeAsync()
        {
            IQueryable<ScadenzaViewModel> queryLinq = dbContext.Scadenze
                .AsNoTracking()
                .Select(scadenze => ScadenzaViewModel.FromEntity(scadenze)); //Usando metodi statici come FromEntity, la query potrebbe essere inefficiente. Mantenere il mapping nella lambda oppure usare un extension method personalizzato

            List<ScadenzaViewModel> scadenza = await queryLinq.ToListAsync(); //La query al database viene inviata qui, quando manifestiamo l'intenzione di voler leggere i risultati

            return scadenza;
        }

        public async Task<ScadenzaViewModel> GetScadenzaAsync(int id)
        {
            IQueryable<ScadenzaViewModel> queryLinq = dbContext.Scadenze
                .AsNoTracking()
                .Where(scadenza => scadenza.IDScadenza == id)
                .Select(scadenza => ScadenzaViewModel.FromEntity(scadenza)); //Usando metodi statici come FromEntity, la query potrebbe essere inefficiente. Mantenere il mapping nella lambda oppure usare un extension method personalizzato
            
            ScadenzaViewModel viewModel = await queryLinq.SingleAsync();
                                                           //.FirstOrDefaultAsync(); //Restituisce null se l'elenco è vuoto e non solleva mai un'eccezione
                                                           //.SingleOrDefaultAsync(); //Tollera il fatto che l'elenco sia vuoto e in quel caso restituisce null, oppure se l'elenco contiene più di 1 elemento, solleva un'eccezione
                                                           //.FirstAsync(); //Restituisce il primo elemento, ma se l'elenco è vuoto solleva un'eccezione
                
            return viewModel;
        }
        public async Task<ScadenzaEditInputModel> GetScadenzaForEditingAsync(int id)
        {
            IQueryable<ScadenzaEditInputModel> queryLinq = dbContext.Scadenze
                .AsNoTracking()
                .Where(scadenza => scadenza.IDScadenza == id)
                .Select(scadenza => ScadenzaEditInputModel.FromEntity(scadenza)); //Usando metodi statici come FromEntity, la query potrebbe essere inefficiente. Mantenere il mapping nella lambda oppure usare un extension method personalizzato

            ScadenzaEditInputModel viewModel = await queryLinq.FirstOrDefaultAsync();

            if (viewModel == null)
            {
                logger.LogWarning("Scadenza {id} not found", id);
                throw new ScadenzaNotFoundException(id);
            }

            return viewModel;
        }

        public async Task DeleteScadenzaAsync(ScadenzaDeleteInputModel inputModel)
        {
            Scadenza scadenza = await dbContext.Scadenze.FindAsync(inputModel.IDScadenza);
            if (scadenza == null)
            {
                throw new ScadenzaNotFoundException(inputModel.IDScadenza);
            }
            dbContext.Remove(scadenza);
            await dbContext.SaveChangesAsync();
        }
        public async Task<ScadenzaViewModel> EditScadenzaAsync(ScadenzaEditInputModel inputModel)
        {
            Scadenza scadenza = await dbContext.Scadenze.FindAsync(inputModel.IDScadenza);

            if (scadenza == null)
            {
                throw new ScadenzaNotFoundException(inputModel.IDScadenza);
            }
            try
            {   
                //Mapping
                scadenza.Beneficiario=inputModel.Beneficiario;
                scadenza.DataScadenza=inputModel.DataScadenza;
                scadenza.DataPagamento=inputModel.DataPagamento;
                scadenza.GiorniRitardo=inputModel.GiorniRitardo;
                scadenza.Sollecito=inputModel.Sollecito;
                scadenza.Importo=inputModel.Importo;
                scadenza.IDBeneficiario=inputModel.IDBeneficiario;
                scadenza.IDUser=inputModel.IdUser;


                dbContext.Update(scadenza);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ScadenzaViewModel.FromEntity(scadenza);
        }
    }
}
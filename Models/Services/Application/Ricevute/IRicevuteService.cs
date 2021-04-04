using System.Collections.Generic;
using System.Threading.Tasks;
using Scadenzario.Models.Entities;
using Scadenzario.Models.InputModels;
using Scadenzario.Models.ViewModels;

public interface IRicevuteService
{
       
    Task<RicevutaViewModel> CreateRicevutaAsync(List<RicevutaCreateInputModel> input);
    List<RicevutaViewModel> GetRicevute(int id);
    Task DeleteRicevutaAsync(int Id);
    Task<RicevutaViewModel> GetRicevutaAsync(int id);
   
        
}
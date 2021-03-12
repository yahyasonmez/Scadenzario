using System;
using System.Collections.Generic;
using Scadenzario.Models.ViewModels;

namespace Scadenzario.Models.Services.Application
{
    public class ScadenzeService
    {
        public List<ScadenzeViewModel> GetScadenze()
        {
            List<ScadenzeViewModel> lista = new();
            var rnd = new Random();
            for(int i=1; i<=20; i++)
            {
                var importo = Convert.ToDecimal(rnd.NextDouble() * 10 + 10);
                var scadenza = new ScadenzeViewModel();
                scadenza.IDScadenza=i;
                scadenza.Beneficiario="Enel";
                scadenza.DataPagamento = new DateTime(25, 04, 2021);
                scadenza.DataScadenza = new DateTime(25, 05, 2021);
                scadenza.IdUser="12wert5678ilkm";
                scadenza.GiorniRitardo=5;
                scadenza.Importo=importo;
                scadenza.Sollecito=false;
                lista.Add(scadenza);   
            }
            return lista;
        }
    }
}
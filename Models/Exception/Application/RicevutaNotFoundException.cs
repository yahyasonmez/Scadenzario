using System;

namespace Scadenzario.Models.Exceptions.Application
{
    public class RicevutaNotFoundException : Exception
    {
        public RicevutaNotFoundException(int Id) : base($"Ricevuta {Id} not found")
        {
        }
    }
}
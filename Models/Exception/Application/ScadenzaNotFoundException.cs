using System;

namespace Scadenzario.Models.Exceptions.Application
{
    public class ScadenzaNotFoundException : Exception
    {
        public ScadenzaNotFoundException(int IDScadenza) : base($"Scadenza {IDScadenza} not found")
        {
        }
    }
}
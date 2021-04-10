using System.Collections.Generic;

namespace Scadenzario.Models.ViewModels
{
    public class ListViewModel<T>
    {
        public List<T> Results {get;set;}
        public int TotalCount {get;set;}
    }
}
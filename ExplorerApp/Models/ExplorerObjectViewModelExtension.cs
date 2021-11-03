using System.Collections.Generic;
using System.Linq;

namespace ExplorerApp.Models
{
    public static class ExplorerObjectViewModelExtension
    {
        public static ExplorerObjectViewModel GetExplorerObjectByRoute(this List<ExplorerObjectViewModel> directoriesList, string route)
            => directoriesList.FirstOrDefault(x => x.Route == route);
    }
}

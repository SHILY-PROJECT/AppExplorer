using System.Linq;
using System.Collections.Generic;
using ExplorerApp.Models;

namespace ExplorerApp.Extensions
{
    public static class ExplorerObjectViewModelExtension
    {
        public static ExplorerObjectViewModel GetExplorerObjectByRoute(this List<ExplorerObjectViewModel> directoriesList, string route)
            => directoriesList.FirstOrDefault(x => x.Route == route);
    }
}

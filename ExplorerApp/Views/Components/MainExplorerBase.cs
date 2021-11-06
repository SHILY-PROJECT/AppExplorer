using Microsoft.AspNetCore.Components;
using ExplorerApp.Views.Components.MainExplorerViewComponents;
using System.Threading.Tasks;
using ExplorerApp.Enums;
using ExplorerApp.Models;

namespace ExplorerApp.Views.Components
{
    public class MainExplorerBase : ComponentBase
    {
        protected DescendantCompinentsMainExplorer DescendantComponents { get; set; } = new();

        protected void SwitchRouteDirection(bool routeDirection)
        {
            if (DataStore.Instance.GetExplorerObjectFromHistory(routeDirection, out var expObj))
                DescendantComponents.DisplayExplorerObject.OnGoToRouteFromHistory.InvokeAsync(expObj);
        }

        protected void SetCurrentDirectoryInNavigateBar()
            => DescendantComponents.NavigateBar.SetCurrentDirectory(DataStore.Instance.CurrentDirectory);

        protected void SortRouteObjects(SortOptionsEnum sortOption)
            => DescendantComponents.DisplayExplorerObject.OnGoToRouteFromHistory
            .InvokeAsync(DataStore.Instance.GetObjectsInCurrentDirectory(sortOption));
        
    }
}

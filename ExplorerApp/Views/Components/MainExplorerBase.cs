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

        protected override Task OnInitializedAsync()
        {
            DataStore.Instance.SetBaseExplorerObjectAndDefaultSettings();
            return base.OnInitializedAsync();
        }

        protected void SwitchRouteDirection(bool routeDirection)
        {
            if (DataStore.Instance.GetExplorerObjectFromHistory(routeDirection, out var expObj))
                DescendantComponents.DisplayExplorerObject.OnGoToRouteFromHistory.InvokeAsync(expObj);
        }

        protected void ChangeNavigationBarUIDisplay()
        {
            DescendantComponents.NavigateBar.SetCurrentDirectory(DataStore.Instance.CurrentDirectory);
            DescendantComponents.NavigateBar.SetDefaultSortOption();
        }

        protected void SortRouteObjects(SortOptionsEnum sortOption)
            => DescendantComponents.DisplayExplorerObject.OnSortedObjects
            .InvokeAsync(DataStore.Instance.GetObjectsInCurrentDirectory(sortOption));

    }
}

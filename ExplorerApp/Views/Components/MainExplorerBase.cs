using Microsoft.AspNetCore.Components;
using ExplorerApp.Views.Components.MainExplorerViewComponents;
using ExplorerApp.Models;

namespace ExplorerApp.Views.Components
{
    public class MainExplorerBase : ComponentBase
    {
        [Parameter]
        public bool ChangeRouteDirection { get; set; }

        protected DescendantCompinentsMainExplorer DescendantComponents { get; set; } = new();

        protected void SwitchRouteDirection(bool routeDirection)
        {
            if (DataStore.Instance.GetExplorerObjectFromHistory(routeDirection, out var expObj))
                DescendantComponents.DisplayExplorerObject.OnGoToRouteFromHistory.InvokeAsync(expObj);
        }

    }
}

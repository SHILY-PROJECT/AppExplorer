using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ExplorerApp.Views.Components.MainExplorerViewComponents
{
    public class NavigateBarBase : ComponentBase
    {
        [Parameter]
        public EventCallback<bool> OnSwitchRouteHistory { get; set; }
        
        protected async Task SwitchRoute(bool routeDirection)
        {
            await OnSwitchRouteHistory.InvokeAsync(routeDirection);
        }
    }
}

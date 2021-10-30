using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ExplorerApp.Views.Components.MainExplorerViewComponents
{
    public class NavigateBarBase : ComponentBase
    {
        [Parameter]
        public EventCallback<bool> OnNavChangeRouteBackOrNext { get; set; }

        protected async Task ChangeRoute(bool routeDirection)
        {
            await OnNavChangeRouteBackOrNext.InvokeAsync(routeDirection);
        }
    }
}

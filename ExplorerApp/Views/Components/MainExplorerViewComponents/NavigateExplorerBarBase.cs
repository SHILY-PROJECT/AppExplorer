using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ExplorerApp.Views.Components.MainExplorerViewComponents
{
    public class NavigateExplorerBarBase : ComponentBase
    {
        [Parameter]
        public EventCallback<bool> EventRoute { get; set; }

        protected async Task RouteBack()
        {
            await EventRoute.InvokeAsync(false);
        }
        protected async Task RouteNext() => await EventRoute.InvokeAsync(true);

    }
}

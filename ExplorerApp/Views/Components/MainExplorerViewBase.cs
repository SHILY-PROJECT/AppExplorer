using Microsoft.AspNetCore.Components;
using ExplorerApp.Views.Components.MainExplorerViewComponents;

namespace ExplorerApp.Views.Components
{
    public class MainExplorerViewBase : ComponentBase
    {
        //[Parameter]
        //public EventCallback<bool> OnChange { get; set; }
        [Parameter]
        public bool ChangeRouteDirection { get; set; }

        protected void SwitchRouteDirection(bool routeDirection) => ChangeRouteDirection = routeDirection;

        
    }
}

using Microsoft.AspNetCore.Components;
using ExplorerApp.Views.Components.MainExplorerViewComponents;
using ExplorerApp.Models;

namespace ExplorerApp.Views.Components
{
    public class MainExplorerViewBase : ComponentBase
    {
        [Parameter]
        public bool ChangeRouteDirection { get; set; }

        protected DescendantsMainExplorerView Descendants { get; set; }

        protected void SwitchRouteDirection(bool routeDirection)
        {
            

            //DisplayExplorerObjectBase.OnGoToRoute.InvokeAsync();
        }



    }
}

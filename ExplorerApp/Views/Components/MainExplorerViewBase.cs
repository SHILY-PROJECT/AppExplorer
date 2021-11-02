using Microsoft.AspNetCore.Components;
using ExplorerApp.Views.Components.MainExplorerViewComponents;
using ExplorerApp.Models;

namespace ExplorerApp.Views.Components
{
    public class MainExplorerViewBase : ComponentBase
    {
        [Parameter]
        public bool ChangeRouteDirection { get; set; }

        protected DescendantsMainExplorerView Descendants { get; set; } = new();

        protected void SwitchRouteDirection(bool routeDirection)
        {
            
            if (DataStore.Instance.GetRouteFromHistory(routeDirection, out var route))
            {
                //Descendants.ListExplorerObjectsView.SetNewListExplorerObjects(explorerObjects);

                Descendants.DisplayExplorerObjectView.OnGoToRoute.InvokeAsync(route);
            }
            //DisplayExplorerObjectBase.OnGoToRoute.InvokeAsync();
        }

        //private void GoToRouteBackOrNext(bool routeDirection)
        //{
        //    if (DataStore.Instance.GetRouteFromHistory(routeDirection, out var explorerObjects))
        //    {
        //        ListExplorerObjects = explorerObjects;
        //    }
        //}

    }
}

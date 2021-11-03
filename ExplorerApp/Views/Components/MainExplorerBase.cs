﻿using Microsoft.AspNetCore.Components;
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
            
            if (DataStore.Instance.GetRouteFromHistory(routeDirection, out var expObj))
            {
                //Descendants.ListExplorerObjectsView.SetNewListExplorerObjects(explorerObjects);

                //Descendants.DisplayExplorerObjectView.OnGoToRoute.InvokeAsync(route);
                //DescendantComponents.DisplayExplorerObjectView.GoToRouteFromHistory(expObj);
                DescendantComponents.DisplayExplorerObject.OnGoToRouteFromHistory.InvokeAsync(expObj);
            }           
        }

    }
}

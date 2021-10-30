using ExplorerApp.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ExplorerApp.Views.Components.MainExplorerViewComponents
{
    public class ListExplorerObjectsBase : ComponentBase
    {
        [Parameter]
        public EventCallback<bool> OnChangeRouteBackOrNext { get; set; }

        public List<ExplorerObjectViewModel> ListExplorerObjects { get; set; }

        protected override Task OnInitializedAsync()
        {
            LoadParentRoute();
            return base.OnInitializedAsync();
        }

        private void LoadParentRoute()
            => ListExplorerObjects = new(DataStore.Instance.GetRouteObjects(DataStore.Instance.ParentRoute));

        protected void GoToRouteDirectionBackOrNext(bool routeDirection)
        {
            //ListExplorerObjects = null;
            ListExplorerObjects = new(DataStore.Instance.SwitchRouteDirection(routeDirection));
        }

        protected void GoToRoute(string route)
        {
            ListExplorerObjects = null;
            ListExplorerObjects = new(DataStore.Instance.GetRouteObjects(route));
        }
    }
}

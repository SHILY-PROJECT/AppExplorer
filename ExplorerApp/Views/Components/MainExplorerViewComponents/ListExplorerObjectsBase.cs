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
        //[Parameter]
        //public EventCallback<bool> OnChangeRouteBackOrNext { get; set; }

        [Parameter]
        public List<ExplorerObjectViewModel> ListExplorerObjects { get; set; }

        protected internal DisplayExplorerObject ChildDisplayExplorerObject { get; set; }

        protected override Task OnInitializedAsync()
        {
            LoadParentRoute();
            return base.OnInitializedAsync();
        }

        public void SetNewListExplorerObjects(List<ExplorerObjectViewModel> listExplorerObjects)
            => ListExplorerObjects = listExplorerObjects;      

        private void LoadParentRoute()
            => ListExplorerObjects = DataStore.Instance.GetRouteObjects(DataStore.Instance.BaseRoute);

        protected void GoToRoute(string route)
        {
            ListExplorerObjects = null;
            ListExplorerObjects = DataStore.Instance.GetRouteObjects(route);
        }

        //protected void DisplayExplorerObjects(List<ExplorerObjectViewModel> explorerObjects)
        //{
        //    ListExplorerObjects = null;
        //    ListExplorerObjects = explorerObjects;
        //}
    }
}

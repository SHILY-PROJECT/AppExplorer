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
        public List<ExplorerObjectViewModel> ListExplorerObjects { get; set; }

        [Parameter]
        public EventCallback OnChangeCurrentDirectory { get; set; }

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
            OnChangeCurrentDirectory.InvokeAsync();
        }

        protected void DisplayExplorerObjects(List<ExplorerObjectViewModel> expObj)
        {
            ListExplorerObjects = null;
            ListExplorerObjects = expObj;
            OnChangeCurrentDirectory.InvokeAsync();
        }
    }
}

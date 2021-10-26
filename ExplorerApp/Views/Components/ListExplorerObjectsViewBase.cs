using ExplorerApp.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ExplorerApp.Views.Components
{
    public class ListExplorerObjectsViewBase : ComponentBase
    {
        public List<ExplorerObjectViewModel> ListExplorerObjects { get; set; }

        protected override Task OnInitializedAsync()
        {
            LoadParentRoute();
            return base.OnInitializedAsync();
        }

        private void LoadParentRoute()
            => ListExplorerObjects = new(DataStore.Instance.GetRouteObjects(DataStore.Instance.ParentRoute));
    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ExplorerApp.Views.Components.MainExplorerViewComponents
{
    public class NavigateBarBase : ComponentBase
    {
        [Parameter]
        public EventCallback<bool> OnSwitchRouteHistory { get; set; }

        [Inject]
        IJSRuntime JSRuntime { get; set; }

        protected string CurrentDirectory { get; set; }
        
        protected async Task SwitchRoute(bool routeDirection)
            => await OnSwitchRouteHistory.InvokeAsync(routeDirection);

        internal void SetCurrentDirectory(string currentDirectory)
            => CurrentDirectory = currentDirectory;

        protected async Task CopyTextToClipboard()
            => await JSRuntime.InvokeVoidAsync("clipboardCopy.copyText", CurrentDirectory);

        protected override Task OnInitializedAsync()
        {
            CurrentDirectory = DataStore.Instance.CurrentDirectory;
            return base.OnInitializedAsync();
        }
        
    }
}

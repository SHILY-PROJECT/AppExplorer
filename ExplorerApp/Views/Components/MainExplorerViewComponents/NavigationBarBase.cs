using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExplorerApp.Enums;
using System;

namespace ExplorerApp.Views.Components.MainExplorerViewComponents
{
    public class NavigationBarBase : ComponentBase
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public EventCallback<bool> OnSwitchRouteHistory { get; set; }

        [Parameter]
        public EventCallback<SortOptionsEnum> OnSortOption { get; set; }

        private SortOptionsEnum _currentSortOption;

        protected SortOptionsEnum CurrentSortOption
        {
            get => _currentSortOption;
            set
            {
                _currentSortOption = value;
                ChangedSortOption();
            }
        }

        protected Dictionary<SortOptionsEnum, string> SortingTypes = new()
        {
            [SortOptionsEnum.SortByDefault] = "Сортировка по умолчанию",
            //[SortOptionsEnum.SortByType] = "Сортировать по типу",
            [SortOptionsEnum.SortByAlphabet] = "Сортировать по алфавиту",
            [SortOptionsEnum.SortBySizeFromMinToMax] = "Сортировать по размеру ⬆",
            [SortOptionsEnum.SortBySizeFromMaxToMin] = "Сортировать по размеру ⬇"
        };

        internal void SetCurrentDirectory(string currentDirectory)
            => CurrentDirectory = currentDirectory;

        internal void SetDefaultSortOption()
        {
            _currentSortOption = SortOptionsEnum.SortByDefault;
            StateHasChanged();
        }

        protected async void ChangedSortOption()
            => await OnSortOption.InvokeAsync(CurrentSortOption);      

        protected string CurrentDirectory { get; set; }

        protected async Task SwitchRoute(bool routeDirection)
            => await OnSwitchRouteHistory.InvokeAsync(routeDirection);

        protected async Task CopyTextToClipboard()
            => await JSRuntime.InvokeVoidAsync("clipboardCopy.copyText", CurrentDirectory);

        protected override Task OnInitializedAsync()
        {
            CurrentDirectory = DataStore.Instance.CurrentDirectory;
            return base.OnInitializedAsync();
        }
        
    }
}

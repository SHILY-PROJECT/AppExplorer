using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ExplorerApp.Models;
using ExplorerApp.Enums;

namespace ExplorerApp.Views.Components
{
    public class DisplayExplorerObjectBase : ComponentBase
    {
        [Parameter]
        public ExplorerObjectViewModel ExplorerObject { get; set; }

        [Parameter]
        public EventCallback<string> OnRoute { get; set; }

        protected async Task OpenDirectory() => await (ExplorerObject.TypeObject switch
        {
            ExplorerObjectTypeEnum.Disc or ExplorerObjectTypeEnum.Folder => OnRoute.InvokeAsync(ExplorerObject.Route),
            ExplorerObjectTypeEnum.File => ProcessingFile(),
            _ => throw new NotImplementedException()
        });
        
        private static Task ProcessingFile()
        {
            // заглушка
            return Task.FromResult<string>(null);
        }
    }
}

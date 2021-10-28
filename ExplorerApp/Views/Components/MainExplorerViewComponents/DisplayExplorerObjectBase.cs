using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ExplorerApp.Models;
using ExplorerApp.Enums;
using System.Diagnostics;
using System.IO;

namespace ExplorerApp.Views.Components.MainExplorerViewComponents
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
            ExplorerObjectTypeEnum.File => ProcessingFile(ExplorerObject.ObjectFullName.LocalPath),
            _ => throw new NotImplementedException()
        });

        private static Task ProcessingFile(string path)
        {
            // заглушка
            return Task.FromResult<string>(null);
        }
    }
}

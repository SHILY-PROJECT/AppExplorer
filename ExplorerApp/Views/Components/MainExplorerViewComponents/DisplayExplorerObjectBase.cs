using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.IO;
using System.Diagnostics;
using ExplorerApp.Models;
using ExplorerApp.Enums;

namespace ExplorerApp.Views.Components.MainExplorerViewComponents
{
    public class DisplayExplorerObjectBase : ComponentBase
    {
        [Parameter]
        public ExplorerObjectViewModel ExplorerObject { get; set; }

        [Parameter]
        public EventCallback<string> OnGoToRoute { get; set; }

        protected async Task OpenDirectory() => await (ExplorerObject.TypeObject switch
        {
            ExplorerObjectTypeEnum.Disc or ExplorerObjectTypeEnum.Folder => OnGoToRoute.InvokeAsync(ExplorerObject.Route),
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

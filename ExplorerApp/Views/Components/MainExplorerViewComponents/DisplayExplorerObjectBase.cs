using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.IO;
using System.Diagnostics;
using ExplorerApp.Models;
using ExplorerApp.Enums;
using System.Collections.Generic;

namespace ExplorerApp.Views.Components.MainExplorerViewComponents
{
    public class DisplayExplorerObjectBase : ComponentBase
    {
        [Parameter]
        public ExplorerObjectViewModel ExplorerObject { get; set; }

        [Parameter]
        public EventCallback<string> OnGoToRoute { get; set; }

        [Parameter]
        public EventCallback<List<ExplorerObjectViewModel>> OnGoToRouteFromHistory { get; set; }

        protected async Task OpenExplorerObject() => await (ExplorerObject.TypeObject switch
        {
            ExplorerObjectTypeEnum.Disc or ExplorerObjectTypeEnum.Folder => OnGoToRoute.InvokeAsync(ExplorerObject.Route),
            ExplorerObjectTypeEnum.File => ProcessingFile(ExplorerObject.ObjectFullName.LocalPath),
            _ => throw new NotImplementedException()
        });

        // заглушка
        private static Task ProcessingFile(string path) => Task.FromResult<string>(null);
        
    }
}

using ExplorerApp.Models;
using Microsoft.AspNetCore.Components;

namespace ExplorerApp.Views.Components
{
    public class DisplayExplorerObjectBase : ComponentBase
    {
        [Parameter]
        public ExplorerObjectViewModel ExplorerObject { get; set; }
    }
}

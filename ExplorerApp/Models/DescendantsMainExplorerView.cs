using ExplorerApp.Views.Components.MainExplorerViewComponents;

namespace ExplorerApp.Models
{
    public class DescendantsMainExplorerView
    {
        public NavigateBar NavigateBar { get; set; }
        public TreeDirectories TreeDirectories { get; set; }
        public ListExplorerObjects ListExplorerObjects { get; set; }
        public DisplayExplorerObject DisplayExplorerObject
        {
            get
            {
                if (DisplayExplorerObject == null) DisplayExplorerObject = ListExplorerObjects.ChildDisplayExplorerObject;
                return DisplayExplorerObject;
            }
            set => DisplayExplorerObject = value;
        }
    }
}

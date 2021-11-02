using ExplorerApp.Views.Components.MainExplorerViewComponents;

namespace ExplorerApp.Models
{
    public class DescendantsMainExplorerView
    {
        public NavigateBar NavigateBarView { get; set; }

        public TreeDirectories TreeDirectoriesView { get; set; }

        public ListExplorerObjects ListExplorerObjectsView { get; set; }

        public DisplayExplorerObject DisplayExplorerObjectView
        {
            get
            {
                if (DisplayExplorerObjectView == null)
                    DisplayExplorerObjectView = ListExplorerObjectsView.ChildDisplayExplorerObject;
                return DisplayExplorerObjectView;
            }
            set => DisplayExplorerObjectView = value;
        }
    }
}

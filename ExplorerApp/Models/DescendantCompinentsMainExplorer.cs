using ExplorerApp.Views.Components.MainExplorerViewComponents;

namespace ExplorerApp.Models
{
    public class DescendantCompinentsMainExplorer
    {
        private NavigationBar _navigateBar;
        private TreeDirectories _treeDirectories;
        private ListExplorerObjects _listExplorerObjects;
        private DisplayExplorerObject _displayExplorerObject;

        public NavigationBar NavigateBar
        { 
            get => _navigateBar;
            set => _navigateBar = value;
        }

        public TreeDirectories TreeDirectories
        {
            get => _treeDirectories;
            set => _treeDirectories = value;
        }

        public ListExplorerObjects ListExplorerObjects
        {
            get => _listExplorerObjects;            
            set => _listExplorerObjects = value; 
        }

        public DisplayExplorerObject DisplayExplorerObject
        {
            get => _displayExplorerObject ??= _listExplorerObjects.ChildDisplayExplorerObject;
            set => _displayExplorerObject = value;
        }
    }
}

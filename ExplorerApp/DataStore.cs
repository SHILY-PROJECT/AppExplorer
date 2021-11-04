using System;
using System.IO;
using System.Collections.Generic;
using ExplorerApp.Models;
using System.Linq;
using ExplorerApp.Extensions;

namespace ExplorerApp
{
    internal class DataStore
    {
        private static DataStore _instance;
        private int _currentPositionInHistory = 0;

        internal static DataStore Instance { get => _instance ??= new(); }
        internal Uri BaseDirectoryFullName { get; private set; }
        internal string BaseRoute { get; private set; }

        private ExplorerObjectViewModel CurrentExplorerObject { get; set; }
        private List<ExplorerObjectViewModel> AppDirectories { get; set; } = new();
        private List<ExplorerObjectViewModel> NavigationHistoryRoutesQueue { get; set; } = new();

        private DataStore()
        {
            BaseDirectoryFullName = new(Path.GetDirectoryName(Environment.CurrentDirectory));
            BaseRoute = new Uri(Environment.CurrentDirectory).AbsolutePath.Replace(BaseDirectoryFullName.AbsolutePath, "");
            this.ConfigureData();
        }

        internal List<ExplorerObjectViewModel> GetRouteObjects(string route)
        {
            _currentPositionInHistory++;

            CurrentExplorerObject = AppDirectories.GetExplorerObjectByRoute(route);
            NavigationHistoryRoutesQueue.Add(CurrentExplorerObject);

            return CurrentExplorerObject.ObjectsInCurrentDirectory;
        }

        internal bool GetExplorerObjectFromHistory(bool routeDirection, out List<ExplorerObjectViewModel> explorerObjects)
        {
            explorerObjects = null;

            var countRouteQueue = NavigationHistoryRoutesQueue.Count - 1;

            if ((routeDirection && _currentPositionInHistory >= countRouteQueue) ||
                (!routeDirection && countRouteQueue <= 1)) return false;

            if (routeDirection) _currentPositionInHistory++;
            else _currentPositionInHistory--;

            explorerObjects = NavigationHistoryRoutesQueue[_currentPositionInHistory].ObjectsInCurrentDirectory;

            return explorerObjects != null;
        }

        private void ConfigureData()
        {
            var baseExpObj = new ExplorerObjectViewModel(BaseDirectoryFullName, new DirectoryInfo(Environment.CurrentDirectory));
            this.AppDirectories.Add(baseExpObj);
            this.NavigationHistoryRoutesQueue.Add(baseExpObj);
            this.CreateTreeView(Environment.CurrentDirectory);
        }

        private void CreateTreeView(string path)
            => Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories).ToList()
            .ForEach(folder => this.AppDirectories.Add(new ExplorerObjectViewModel(BaseDirectoryFullName, new DirectoryInfo(folder))));
    }
}

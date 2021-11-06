using System;
using System.IO;
using System.Collections.Generic;
using ExplorerApp.Models;
using System.Linq;
using ExplorerApp.Extensions;
using ExplorerApp.Enums;

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
        private List<ExplorerObjectViewModel> NavigationHistoryQueue { get; set; } = new();

        internal string CurrentDirectory
            => CurrentExplorerObject.ObjectFullName.LocalPath;

        private DataStore()
        {
            BaseDirectoryFullName = new(Path.GetDirectoryName(Environment.CurrentDirectory));
            BaseRoute = new Uri(Environment.CurrentDirectory).AbsolutePath.Replace(BaseDirectoryFullName.AbsolutePath, ""); 
            
            ConfigureData();
        }

        internal void SetBaseExplorerObject()
            => CurrentExplorerObject = AppDirectories.GetExplorerObjectByRoute(BaseRoute);

        //internal List<ExplorerObjectViewModel> GetObjectsInCurrentDirectory()
        //    => CurrentExplorerObject.ObjectsInCurrentDirectory;

        internal List<ExplorerObjectViewModel> GetObjectsInCurrentDirectory(SortOptionsEnum sortOption) => sortOption switch
        {
            SortOptionsEnum.SortByDefault => CurrentExplorerObject.ObjectsInCurrentDirectory,
            SortOptionsEnum.SortByType => CurrentExplorerObject.ObjectsInCurrentDirectory.OrderBy(x => x.TypeObject).ToList(),
            SortOptionsEnum.SortByAlphabet => CurrentExplorerObject.ObjectsInCurrentDirectory.OrderBy(x => x.ObjectName).ToList(),
            SortOptionsEnum.SortBySizeFromMinToMax => CurrentExplorerObject.ObjectsInCurrentDirectory.OrderBy(x => x.SizeInBytes).ToList(),
            SortOptionsEnum.SortBySizeFromMaxToMin => CurrentExplorerObject.ObjectsInCurrentDirectory.OrderByDescending(x => x.SizeInBytes).ToList(),
            _ => CurrentExplorerObject.ObjectsInCurrentDirectory
        };

        internal List<ExplorerObjectViewModel> GetRouteObjects(string route)
        {
            _currentPositionInHistory++;

            if (NavigationHistoryQueue.ElementAtOrDefault(_currentPositionInHistory) != null)
                NavigationHistoryQueue.RemoveRange(_currentPositionInHistory, NavigationHistoryQueue.Count - _currentPositionInHistory);

            CurrentExplorerObject = AppDirectories.GetExplorerObjectByRoute(route);
            NavigationHistoryQueue.Add(CurrentExplorerObject);

            return CurrentExplorerObject.ObjectsInCurrentDirectory;
        }

        internal bool GetExplorerObjectFromHistory(bool routeDirection, out List<ExplorerObjectViewModel> explorerObjects)
        {
            explorerObjects = null;

            var countRouteQueue = NavigationHistoryQueue.Count - 1;

            if ((routeDirection && _currentPositionInHistory >= countRouteQueue) ||
                (!routeDirection && (countRouteQueue <= 1 || _currentPositionInHistory <= 1))) return false;

            if (routeDirection) _currentPositionInHistory++;
            else _currentPositionInHistory--;

            var expObj = NavigationHistoryQueue[_currentPositionInHistory];
            CurrentExplorerObject = expObj;
            explorerObjects = expObj.ObjectsInCurrentDirectory;

            return explorerObjects != null;
        }

        private void ConfigureData()
        {
            var baseExpObj = new ExplorerObjectViewModel(BaseDirectoryFullName, new DirectoryInfo(Environment.CurrentDirectory));
            CurrentExplorerObject = baseExpObj;

            AppDirectories.Add(baseExpObj);
            NavigationHistoryQueue.Add(baseExpObj);
            CreateTreeView(Environment.CurrentDirectory);
        }

        private void CreateTreeView(string path)
            => Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories).ToList()
            .ForEach(folder => AppDirectories.Add(new ExplorerObjectViewModel(BaseDirectoryFullName, new DirectoryInfo(folder))));
    }
}

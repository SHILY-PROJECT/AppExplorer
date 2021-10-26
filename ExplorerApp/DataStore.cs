using System;
using System.IO;
using System.Collections.Generic;
using ExplorerApp.Models;
using System.Linq;

namespace ExplorerApp
{
    internal class DataStore
    {
        internal static DataStore Instance;

        internal Uri ParentDirectoryFullName { get; private set; }

        internal string ParentRoute { get; private set; }

        private List<FolderObjectViewModel> AppDirectories { get; set; }

        private List<FolderObjectViewModel> NavigationQueue { get; set; }

        private List<ExplorerObjectViewModel> CurrentExplorerObjects { get; set; }

        //private List<IndexedObjectViewModel> IndexedRoutes { get; set; }

        private DataStore()
        {
            AppDirectories = new();
            NavigationQueue = new();
            ParentDirectoryFullName = new Uri(Path.GetDirectoryName(Environment.CurrentDirectory));
            ParentRoute = new Uri(Environment.CurrentDirectory).AbsolutePath.Replace(ParentDirectoryFullName.AbsolutePath, "");
        }

        internal static void ConfigureData()
        {
            DataStore.Instance = new DataStore();
            var parent = new FolderObjectViewModel(new DirectoryInfo(Environment.CurrentDirectory));
            DataStore.Instance.AppDirectories.Add(parent);
            DataStore.Instance.NavigationQueue.Add(parent);
            DataStore.Instance.CreateTreeView(Environment.CurrentDirectory); 
        }

        internal List<ExplorerObjectViewModel> GetRouteObjects(string route)
        {
            CurrentExplorerObjects = new();
            var routeObjects = AppDirectories.FirstOrDefault(x => x.Route == route);
            CurrentExplorerObjects.AddRange(routeObjects.Folders);
            CurrentExplorerObjects.AddRange(routeObjects.Files);
            return CurrentExplorerObjects;
        }

        private void CreateTreeView(string path)
        {
            foreach (var folder in Directory.EnumerateDirectories(path))
                AppDirectories.Add(new FolderObjectViewModel(new DirectoryInfo(folder)));          
        }

    }
}

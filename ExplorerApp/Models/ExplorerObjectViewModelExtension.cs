using System.Collections.Generic;
using System.Linq;

namespace ExplorerApp.Models
{
    public static class ExplorerObjectViewModelExtension
    {
        public static List<ExplorerObjectViewModel> ExtractExplorerObjects(this FolderObjectViewModel folderObject)
            => folderObject.Folders.Cast<ExplorerObjectViewModel>().Concat(folderObject.Files.Cast<ExplorerObjectViewModel>()).ToList();

        public static List<ExplorerObjectViewModel> GetExplorerObjectsByRoute(this List<FolderObjectViewModel> directoriesList, string route)
        {
            var folderObject = directoriesList.FirstOrDefault(x => x.Route == route);
            if (folderObject == null) return null;
            return folderObject.ExtractExplorerObjects();
        }

        public static List<ExplorerObjectViewModel> GetExplorerObjectsByIndex(this List<FolderObjectViewModel> directoriesList, int index)
        {
            if (index < 0 || index > (directoriesList.Count - 1)) return null;
            var folderObject = directoriesList[index];
            return folderObject.ExtractExplorerObjects();
        }

    }
}

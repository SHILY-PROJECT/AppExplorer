using System;
using System.IO;
using System.Collections.Generic;
using ExplorerApp.Enums;
using System.Linq;

namespace ExplorerApp.Models
{
    public class FolderObjectViewModel : ExplorerObjectViewModel
    {
        public List<FolderObjectViewModel> Folders { get; private set; }

        public List<FileObjectViewModel> Files { get; private set; }

        public FolderObjectViewModel(DirectoryInfo directory)
        {
            Route = new Uri(directory.FullName).AbsolutePath.Replace(DataStore.Instance.ParentDirectoryFullName.AbsolutePath, "");
            ObjectFullName = new Uri(directory.FullName);
            ObjectName = directory.Name;

            if (Route.Contains(":"))
            {
                Route = Route.Replace(":", "");
                TypeObject = ExplorerObjectTypeEnum.Disc;
                Icon = "";
            }
            else
            {
                TypeObject = ExplorerObjectTypeEnum.Folder;
                Icon = "/images/extensions/folder.svg";
            }

            Folders = Directory.EnumerateDirectories(directory.FullName, "*", SearchOption.TopDirectoryOnly)
                .Select(x => new FolderObjectViewModel(new DirectoryInfo(x))).ToList();

            Files = Directory.EnumerateFiles(directory.FullName, "*", SearchOption.TopDirectoryOnly)
                .Select(x => new FileObjectViewModel(new FileInfo(x))).ToList();

            DetermineSizeObject(directory);
        }
    }
}

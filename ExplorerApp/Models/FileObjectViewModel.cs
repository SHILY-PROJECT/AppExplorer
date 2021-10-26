using ExplorerApp.Enums;
using System;
using System.IO;
using System.Linq;

namespace ExplorerApp.Models
{
    public class FileObjectViewModel : ExplorerObjectViewModel
    {
        public FileObjectViewModel(FileInfo file)
        {
            Route = new Uri(file.FullName).AbsolutePath.Replace(DataStore.Instance.ParentDirectoryFullName.AbsolutePath, "");
            ObjectFullName = new Uri(file.FullName);
            ObjectName = file.Name;
            TypeObject = ExplorerObjectTypeEnum.File;

            // костыльный вариант, пока что, не знаю как иначе
            var path = Path.Combine(Environment.CurrentDirectory, @"wwwroot\images\extensions");
            Icon = Directory.GetFiles(path, "*.svg").FirstOrDefault(x => Path.GetFileNameWithoutExtension(x) == file.Extension.Trim('.')) ?? Path.Combine(path, "none.svg");
            Icon = $"/images/extensions/{Path.GetFileName(Icon)}";

            DetermineSizeObject(file);
        }

        
    }
}

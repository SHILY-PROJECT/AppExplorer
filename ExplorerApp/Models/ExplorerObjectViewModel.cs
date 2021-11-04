using ExplorerApp.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExplorerApp.Models
{
    public class ExplorerObjectViewModel
    {
        public string Route { get; set; }

        public string ObjectName { get; set; }

        public Uri ObjectFullName { get; set; }

        public ExplorerObjectTypeEnum TypeObject { get; set; }

        public string Extension { get; set; }

        public string Icon { get; set; }

        public long SizeInBytes { get; private set; }

        public string SizeForView { get; private set; } = "None";

        public List<ExplorerObjectViewModel> ObjectsInCurrentDirectory { get; private set; } = null;

        private ExplorerObjectViewModel(Uri baseDirectoryFullName, string fillName)
        {
            Route = new Uri(fillName).AbsolutePath.Replace(baseDirectoryFullName.AbsolutePath, "");
            ObjectFullName = new Uri(fillName);
            ObjectName = Path.GetFileName(fillName);
        }

        public ExplorerObjectViewModel(Uri baseDirectoryFullName, FileInfo file) : this(baseDirectoryFullName, file.FullName)
        {
            TypeObject = ExplorerObjectTypeEnum.File;

            // костыльный вариант, пока что, не знаю как иначе
            var path = Path.Combine(Environment.CurrentDirectory, @"wwwroot\images\extensions");
            Icon = Directory.GetFiles(path, "*.svg").FirstOrDefault(x => Path.GetFileNameWithoutExtension(x) == file.Extension.Trim('.')) ?? Path.Combine(path, "none.svg");
            Icon = $"/images/extensions/{Path.GetFileName(Icon)}";

            DetermineSizeObject(file);
        }

        public ExplorerObjectViewModel(Uri baseDirectoryFullName, DirectoryInfo directory) : this(baseDirectoryFullName, directory.FullName)
        {
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

            ObjectsInCurrentDirectory = new();

            ObjectsInCurrentDirectory.AddRange(Directory.EnumerateDirectories(directory.FullName, "*", SearchOption.TopDirectoryOnly)
                .Select(x => new ExplorerObjectViewModel(baseDirectoryFullName, new DirectoryInfo(x))));
            ObjectsInCurrentDirectory.AddRange(Directory.EnumerateFiles(directory.FullName, "*", SearchOption.TopDirectoryOnly)
                .Select(x => new ExplorerObjectViewModel(baseDirectoryFullName, new FileInfo(x))));

            DetermineSizeObject(directory);
        }

        protected internal void DetermineSizeObject(DirectoryInfo directory)
        {
            SizeInBytes = Directory.EnumerateFiles(directory.FullName, "*", SearchOption.AllDirectories).Sum(x => new FileInfo(x).Length);
            SizeForView = FormatSize(SizeInBytes);
            Extension = "folder";
        }

        protected internal void DetermineSizeObject(FileInfo file)
        {
            SizeInBytes = file.Length;
            SizeForView = FormatSize(SizeInBytes);
            Extension = file.Extension.Trim('.');
        }

        protected internal string FormatSize(long length)
        {
            string size;

            // этот вариант просто понятнее
            if (length <= (long)Math.Pow(2, 10)) size = length != 0 ? $"1 KB" : "0 KB";
            else if (length <= (long)Math.Pow(2, 20)) size = $"{Math.Round(length / Math.Pow(2, 10))} KB";
            else if (length <= (long)Math.Pow(2, 30)) size = $"{Math.Round(length / Math.Pow(2, 20))} MB";
            else if (length <= (long)Math.Pow(2, 40)) size = $"{Math.Round(length / Math.Pow(2, 30))} GB";
            else if (length <= (long)Math.Pow(2, 50)) size = $"{Math.Round(length / Math.Pow(2, 40))} TB";
            else if (length <= (long)Math.Pow(2, 60)) size = $"{Math.Round(length / Math.Pow(2, 50))} PB";
            else if (length <= (long)Math.Pow(2, 70)) size = $"{Math.Round(length / Math.Pow(2, 60))} EB";
            else if (length <= (long)Math.Pow(2, 80)) size = $"{Math.Round(length / Math.Pow(2, 70))} ZB";
            else if (length <= (long)Math.Pow(2, 90)) size = $"{Math.Round(length / Math.Pow(2, 80))} YB";
            else size = "HZ";

            return size;

            // а этот я свиснул где-то из интернетов ваших (+-зарефачил)
            //var ends = new[] { "Byt", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB", "HZ" };

            //if (length == 0) return $"{0} {ends[0]}";

            //var bytes = Math.Abs(length);
            //var index = (int)Math.Floor(Math.Log(bytes, 1024));
            //var num = Math.Round(bytes / Math.Pow(1024, index), 1);

            //return $"{Math.Sign(length) * num} {ends[index]}";
        }
    }
}

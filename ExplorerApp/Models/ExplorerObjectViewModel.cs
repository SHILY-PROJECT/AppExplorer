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

        public ObjectTypeEnum TypeObject { get; set; }

        public string Icon { get; set; }

        public long SizeInBytes { get; private set; }

        public string SizeForView { get; private set; }       

        public ExplorerObjectViewModel()
        {
            SizeForView = "None";
        }

        protected internal void DetermineSizeObject(DirectoryInfo directory)
        {
            SizeInBytes = Directory.EnumerateFiles(directory.FullName, "*", SearchOption.AllDirectories).Sum(x => (long)x.Length);
            SizeForView = FormatSize(SizeInBytes);
        }

        protected internal void DetermineSizeObject(FileInfo file)
        {
            SizeInBytes = file.Length;
            SizeForView = FormatSize(SizeInBytes);
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

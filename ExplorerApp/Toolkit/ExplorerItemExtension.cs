using ExplorerApp.Interfaces.ExplorerItems;

namespace ExplorerApp.Toolkit;

internal static class ExplorerItemExtension
{
    public static string ViewSize(this IExplorerItem item)
    {
        var index = 0;
        var nameOfSize = new[] { "Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        while (index <= 10)
        {
            if (item.Size <= (long)Math.Pow(2, (++index * 10)))
            {
                var convertedSize = (item.Size / Math.Pow(2, (index - 1) * 10));

                var result = Math.Round(convertedSize, Math.Truncate(convertedSize).ToString().Length switch
                {
                    1 => 2,
                    2 => 1,
                    _ => 0
                })
                .ToString();

                return $"{result} {nameOfSize[index - 1]}";
            }
        }
        return "HZ";
    }
}
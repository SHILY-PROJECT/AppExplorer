namespace ExplorerApp.Toolkit;

internal static class ExplorerItemExtension
{
    public static string ViewSize(this IExplorerItem obj)
    {
        var size = obj.Size;

        var endOf = new[] { "Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        var index = 0;

        while (index <= 10)
        {
            if (size <= (long)Math.Pow(2, (++index * 10)))
            {
                var convertedSize = (size / Math.Pow(2, (index - 1) * 10));
                var result = Convert.ToString(
                    Math.Round(convertedSize, Math.Truncate(convertedSize).ToString().Length switch { 1 => 2, 2 => 1, _ => 0 }));
                return $"{result} {endOf[index - 1]}";
            }
        }
        return "HZ";
    }
}


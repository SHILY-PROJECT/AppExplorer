namespace ExplorerApp.Models.ExplorerModels
{
    internal abstract class ExplorerObjectModel : IExplorerObject
    {
        public Uri? Directory { get; }

        public string Name { get; } = string.Empty;

        public string Route { get; } = string.Empty;

        public string Icon { get; } = string.Empty;

        public long Size { get; }
    }
}

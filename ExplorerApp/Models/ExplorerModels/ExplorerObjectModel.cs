namespace ExplorerApp.Models.ExplorerModels
{
    public abstract class ExplorerObjectModel : IExplorerItem
    {
        public Uri? Directory { get; }

        public string Name { get; } = string.Empty;

        public string Route { get; } = string.Empty;

        public string Icon { get; } = string.Empty;

        public long Size { get; }
    }
}

namespace ExplorerApp.Components
{
    internal abstract class ExplorerObjectBase : IExplorerObject
    {
        public Uri? FullName { get; }

        public string? Name { get; }

        public string? Route { get; }

        public string? Extension { get; }

        public string? Icon { get; }

        public long SizeInBytes { get; }

        public string? SizeForView { get; }
    }
}

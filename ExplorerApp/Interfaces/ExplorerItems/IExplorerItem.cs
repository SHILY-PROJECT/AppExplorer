namespace ExplorerApp.Interfaces.ExplorerItems
{
    public interface IExplorerItem
    {
        /// <summary>
        /// Object directory.
        /// </summary>
        public Uri? Directory { get; }

        /// <summary>
        /// Object name.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Part way.
        /// </summary>
        public string? Route { get; }

        /// <summary>
        /// Displayed icon in the explorer.
        /// </summary>
        public string? Icon { get; }

        /// <summary>
        /// Size in bytes.
        /// </summary>
        public long Size { get; }
    }
}

namespace ExplorerApp.Interfaces.ExplorerItems
{
    internal interface IFile : IExplorerItem
    {
        /// <summary>
        /// File extension.
        /// For example: .exe, .png, .pdf, etc.
        /// </summary>
        public string? Extension { get; }
    }
}

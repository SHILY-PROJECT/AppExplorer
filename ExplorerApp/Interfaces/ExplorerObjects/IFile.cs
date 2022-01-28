namespace ExplorerApp.Interfaces.ExplorerObjects
{
    internal interface IFile : IExplorerObject
    {
        /// <summary>
        /// File extension.
        /// For example: .exe, .png, .pdf, etc.
        /// </summary>
        public string? Extension { get; }
    }
}

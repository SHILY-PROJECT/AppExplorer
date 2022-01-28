namespace ExplorerApp.Models.ExplorerModels
{
    internal sealed class FileModel : ExplorerObjectModel, IFile
    {
        public string? Extension { get; } = string.Empty;

    }
}

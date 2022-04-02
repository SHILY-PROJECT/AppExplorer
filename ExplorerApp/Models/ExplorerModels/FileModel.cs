using ExplorerApp.Interfaces.ExplorerItems;

namespace ExplorerApp.Models.ExplorerModels;

internal sealed class FileModel : ExplorerItem, IFile
{
    public string? Extension { get; } = string.Empty;

}
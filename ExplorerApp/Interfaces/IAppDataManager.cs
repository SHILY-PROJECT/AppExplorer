namespace ExplorerApp.Interfaces;

public interface IAppDataManager
{
    Uri AppDirectory { get; }
    string AppRoute { get; }
}
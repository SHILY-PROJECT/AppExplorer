using ExplorerApp.Interfaces;

namespace ExplorerApp.Components;

internal class AppDataManager : IAppDataManager
{
    private readonly Uri _appDirectory;
    private readonly string _appRoute;

    public Uri AppDirectory { get => _appDirectory; }
    public string AppRoute { get => _appRoute; }

    public AppDataManager()
    {
        if (Path.GetDirectoryName(Environment.CurrentDirectory) is string appDir && new Uri(Environment.CurrentDirectory) is Uri currentDir)
        {
            _appDirectory = new Uri(appDir);
            _appRoute = currentDir.AbsolutePath.Replace(_appDirectory.AbsolutePath, "");
        }
        else throw new InvalidOperationException($"Directory error.");
    }
}
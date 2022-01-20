namespace ExplorerApp.Components
{
    internal class RepositoryManager : IRepositoryManager
    {
        private readonly Uri _appDirectory;
        private readonly string _appRoute;

        public Uri AppDirectory => _appDirectory;
        public string AppRoute => _appRoute;

        public RepositoryManager()
        {
            if (Path.GetDirectoryName(Environment.CurrentDirectory) is string appDir && new Uri(Environment.CurrentDirectory) is Uri currentDir)
            {
                _appDirectory = new Uri(appDir);
                _appRoute = currentDir.AbsolutePath.Replace(_appDirectory.AbsolutePath, "");
            }
            else throw new Exception($"Directory error.");
        }
    }
}
namespace ExplorerApp
{
    public class DataRepository : IDataRepository
    {
        private readonly Uri _appDirectory;
        private readonly string _baseRoute;

        public Uri AppDirectory => _appDirectory;
        public string BaseRoute => _baseRoute;

        public DataRepository()
        {
            if (Path.GetDirectoryName(Environment.CurrentDirectory) is string appDir && new Uri(Environment.CurrentDirectory) is Uri currentDir)
            {
                _appDirectory = new Uri(appDir);
                _baseRoute = currentDir.AbsolutePath.Replace(_appDirectory.AbsolutePath, "");
            }
            else throw new Exception($"Directory error.");
        }
    }
}
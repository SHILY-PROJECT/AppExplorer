namespace ExplorerApp.Interfaces
{
    public interface IDataRepository
    {
        Uri AppDirectory { get; }
        string BaseRoute { get; }
    }
}

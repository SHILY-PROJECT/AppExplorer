using ExplorerApp.Interfaces;

namespace ExplorerApp.Components;

/*
* Cmd hint:  cd "C:\Users\ILYA\Desktop\SHILY PROJECT"
*            start "" "file.ini"
*/

public class Navigator : INavigator
{
    public Navigator(IAppDataManager repository)
    {

    }

    public void Back()
    {
        throw new NotImplementedException();
    }

    public void Forward()
    {
        throw new NotImplementedException();
    }

    public void Open()
    {
        throw new NotImplementedException();
    }

    public void Refresh()
    {
        throw new NotImplementedException();
    }
}
namespace Ovn3;

public interface IMenuClient
{
    void QueueMenu(Menu menu);
    void CloseMenu();

}
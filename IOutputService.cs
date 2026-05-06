namespace Ovn3;

public interface IOutputService
{
    void PrintOptions(OptionsMenu menu);
    void PrintCommandPrompt(Menu menu);
    void PrintMessage(string message);
}
using System;

namespace Ovn3;

public class MenuOption(string key, Action<CLIParser, CLIPrinter, CLIClient> action, string description)
{
    public readonly Action<CLIParser, CLIPrinter, CLIClient>? action = action;
    public readonly string key = key;
    public readonly string description = description;
    
    public void Invoke(CLIParser input, CLIPrinter output, CLIClient client)
    {
        action?.Invoke(input, output, client);
    }

    public bool MatchesCommand(string input)
    {
        return key.Equals(input, StringComparison.OrdinalIgnoreCase);
    }

    public static void Close(CLIParser input, CLIPrinter output, CLIClient client)
    {
        client.CloseMenu();
    }

    public static Action<CLIParser, CLIPrinter, CLIClient> CreateOpenSubmenu(Menu submenu)
    {
        return (input, output, client) => client.QueueMenu(submenu);
    }
}
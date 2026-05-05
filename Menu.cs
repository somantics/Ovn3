using System;
using System.Collections.Generic;
using System.Linq;

namespace Ovn3;

public class Menu(List<MenuOption> options, string message)
{
    private List<MenuOption> options = options;
    public List<MenuOption> Options
    {
        get { return options; }
    }

    readonly private string welcomeMessage = message;
    public string WelcomeMessage 
    {
        get { return welcomeMessage; }
    }

    public void AddCommand(string key, string description, Action<CLIParser, CLIPrinter, CLIClient> action)
    {
        MenuOption newCommand = new(key, action, description);
        options.Add(newCommand);
    }


    public void Run(CLIParser parser, CLIPrinter output, CLIClient client)
    {
        output.PrintOptions(this);
        if (parser.ParseString("Option: ", out string input))
        {
            foreach (MenuOption option in Options)
            {
                if (option.key.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    option.Invoke(parser, output, client);
                    break;
                }
            }
        }
    }
}
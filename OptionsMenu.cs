using System;
using System.Collections.Generic;

namespace Ovn3;
public class OptionsMenu : Menu
{
    public OptionsMenu(string? message, string? prompt) : base(message, prompt)
    {
    }

    private List<MenuOption> options = [];
    public List<MenuOption> Options
    {
        get { return options; }
    }


    public void AddCommand(string key, string description, Action<CLIParser, CLIPrinter, CLIClient> action)
    {
        MenuOption newCommand = new(key, action, description);
        options.Add(newCommand);
    }

    protected void AwaitOption(CLIParser parser, CLIPrinter output, CLIClient client)
    {
        output.PrintCommandPrompt(this);
        if (parser.ParseString(out string input))
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

    public override void Run(CLIParser parser, CLIPrinter output, CLIClient client)
    {
        output.PrintOptions(this);
        AwaitOption(parser, output, client);
    }
}
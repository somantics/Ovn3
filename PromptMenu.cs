using System;

namespace Ovn3;

public delegate bool BusinessFunction(string input, out string result);

public class PromptMenu : Menu
{
    protected BusinessFunction action;
    public PromptMenu(string? message, string? prompt, BusinessFunction action) : base(message, prompt)
    {
        this.action = action;
    }


    public override void Run(CLIParser parser, CLIPrinter output, CLIClient client)
    {
        output.PrintCommandPrompt(this);
        if (parser.ParseString(out string message))
        {
            bool success = action.Invoke(message, out string result);
            output.PrintMessage(result);

            if (success) client.CloseMenu();
        }
        else
        {
            output.PrintMessage("Invalid input, please enter a string.");
        }
    }
}
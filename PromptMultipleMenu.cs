using System.Collections.Generic;

namespace Ovn3;

public delegate bool BusinessFunctionMultiple(string[] input, out string result);
public class PromptMultipleMenu(string? message, string? prompt, BusinessFunctionMultiple action) : Menu(message, prompt)
{
    protected int? amount;
    protected List<string> inputs = [];

    public override void Run(CLIParser parser, CLIPrinter output, CLIClient client)
    {
        if (amount is null)
        {
            PromptAmount(parser, output, client);
        }
        
        output.PrintMessage($"Ange ålder (besökare {inputs.Count + 1}): ");
        if (parser.ParseString(out string message))
        {
            inputs.Add(message);
        }
        else
        {
            output.PrintMessage("Invalid input, please enter a string.");
        }

        if (inputs.Count >= amount)
        {
            
            bool success = action.Invoke(inputs.ToArray(), out string result);
            output.PrintMessage(result);
            ResetInput();

            if (success)
            {
                client.CloseMenu();
            }
        }
    }

    protected void PromptAmount(CLIParser parser, CLIPrinter output, CLIClient client)
    {
        output.PrintCommandPrompt(this);
        if (!parser.ParseAmount(out int result))
        {
            output.PrintMessage("Not a valid amount.");
            return;
        }

        amount = result;
    }

    protected void ResetInput()
    {
        amount = null;
        inputs = [];
    }
}
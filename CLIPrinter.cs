using System;
using System.Text;

namespace Ovn3;

public class CLIPrinter
{
    public void PrintOptions(Menu menu)
    {
        var builder = new StringBuilder();
        builder.Append('\n');
        builder.Append(menu.WelcomeMessage);
        builder.Append('\n');

        foreach (MenuOption command in menu.Options)
        {
            builder.Append($"{command.key}: {command.description}\n");
        }

        Console.WriteLine(builder.ToString());
    }
}
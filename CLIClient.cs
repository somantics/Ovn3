using System.Collections.Generic;

namespace Ovn3;

public class CLIClient(Menu StartMenu)
{
    readonly private CLIParser parser = new();
    readonly private CLIPrinter output = new();
    private Stack<Menu> menus = new([StartMenu]);

    public void Run()
    {
        while(menus.Count > 0)
        {
            var currentMenu = menus.Peek();
            currentMenu.Run(parser, output, this);
        }
    }

    public void QueueMenu(Menu menu)
    {
        menus.Push(menu);
    }

    public void CloseMenu()
    {
        menus.Pop();
    }
}

/*
cliclient displays menus

menus have actions

command parser reads input into int/string depending on what is asked for
*/
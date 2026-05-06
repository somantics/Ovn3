
using System;

namespace Ovn3;
internal class Program
{
    static void Main(string[] args)
    {
        var menu = new OptionsMenu("Välkommen till huvudmenyn!\nSkriv en siffra för att välja funktion.", "Ditt val: ");
        menu.AddCommand("0", "Avsluta", MenuOption.Close);
        menu.AddCommand("1", "Ungdom eller pensionär", MenuOption.Close);
        menu.AddCommand("2", "Pris för sällskap", MenuOption.Close);
        menu.AddCommand("3", "Upprepa tio gånger", MenuOption.Close);

        var menu4 = new PromptMenu(null, "Skriv en mening med minst 3 ord: ", BusinessLogic.DetTredjeOrdet);
        menu.AddCommand("4", "Det tredje ordet", MenuOption.CreateOpenSubmenu(menu4));


        var client = new CLIClient(menu);
        client.Run();

    }
}



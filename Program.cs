namespace Ovn3;
internal class Program
{
    static void Main(string[] args)
    {
        var menu = new OptionsMenu("Välkommen till huvudmenyn!\nSkriv en siffra för att välja funktion.", "Ditt val: ");
        menu.AddCommand("0", "Avsluta", MenuOption.Close);

        var menu1 = new PromptMenu(null, "Ange ålder: ", BusinessLogic.UngdomEllerPensionar);
        menu.AddCommand("1", "Ungdom eller pensionär", MenuOption.CreateOpenSubmenu(menu1));

        var menu2 = new PromptMultipleMenu(null, "Hur många är ni? ", BusinessLogic.PrisForSallskap);
        menu.AddCommand("2", "Pris för sällskap", MenuOption.CreateOpenSubmenu(menu2));

        var menu3 = new PromptMenu(null, "Skriv en text: ", BusinessLogic.UpprepaTioGanger);
        menu.AddCommand("3", "Upprepa tio gånger", MenuOption.CreateOpenSubmenu(menu3));

        var menu4 = new PromptMenu(null, "Skriv en mening med minst 3 ord: ", BusinessLogic.DetTredjeOrdet);
        menu.AddCommand("4", "Det tredje ordet", MenuOption.CreateOpenSubmenu(menu4));


        var client = new CLIClient(menu);
        client.Run();
    }
}



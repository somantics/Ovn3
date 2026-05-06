using System;
using System.Runtime.InteropServices;

namespace Ovn3;

public class BusinessLogic
{
    static void UngdomEllerPensionar()
    {
        Console.Write("Ange ålder: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int alder))    // Jämför med int.Parse(input) --> "hej" --> Exception
        {
            Console.WriteLine("Ogiltig ålder.");
            return;
        }

        if (alder < 20)
        {
            Console.WriteLine("Ungdomspris: 80kr");
        }
        else if (alder > 64)
        {
            Console.WriteLine("Pensionärspris: 90kr");
        }
        else
        {
            Console.WriteLine("Standardpris: 120kr");
        }
    }

    static void PrisForSallskap()
    {
        Console.Write("Hur många personer är ni? ");
        string? antalInput = Console.ReadLine();

        if (!int.TryParse(antalInput, out int antal) || antal <= 0)
        {
            Console.WriteLine("Ogiltigt antal personer.");
            return;
        }

        int total = 0;

        for (int i = 1; i <= antal; i++)
        {
            Console.Write($"Ange ålder för person {i}: ");
            string? alderInput = Console.ReadLine();

            if (!int.TryParse(alderInput, out int alder) || alder < 0)
            {
                Console.WriteLine("Ogiltig ålder.");
                return;
            }

            if (alder < 5 || alder > 100)
            {
                Console.WriteLine($"Person {i}: Gratis");
            }
            else if (alder < 20)
            {
                total += 80;
            }
            else if (alder > 64)
            {
                total += 90;
            }
            else
            {
                total += 120;
            }
        }

        Console.WriteLine($"Antal personer: {antal}");
        Console.WriteLine($"Totalkostnad: {total} kr");
    }

    static void UpprepaTioGanger()
    {
        Console.Write("Skriv en text: ");
        string? text = Console.ReadLine();

        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"{i}. {text} ");
        }

        Console.WriteLine();
    }

    public static bool DetTredjeOrdet(string input, out string result)
    {
        //Console.Write("Skriv en mening med minst 3 ord: ");
        //string? mening = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            result = "Du måste skriva en mening.";
            return false;
        }

        string[] ord = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (ord.Length < 3)
        {
            result = "Mening måste innehålla minst 3 ord.";
            return false;
        }

        result = $"Det tredje ordet är: {ord[2]}";
        return true;
    }
}

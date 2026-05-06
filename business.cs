using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ovn3;

public class BusinessLogic
{
    public static bool UngdomEllerPensionar(string input, out string result)
    {

        if (!int.TryParse(input, out int alder) || alder < 0)    // Jämför med int.Parse(input) --> "hej" --> Exception
        {
            result = "Ogiltig ålder.";
            return false;
        }

        if (alder < 20)
        {
            result = "Ungdomspris: 80kr";
        }
        else if (alder > 64)
        {
            result = "Pensionärspris: 90kr";
        }
        else
        {
            result = "Standardpris: 120kr";
        }

        return true;
    }

    public static bool PrisForSallskap(string[] input, out string result)
    {
        int total = 0;

        var builder = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {

            if (!int.TryParse(input[i], out int alder) || alder < 0)
            {
                builder.Append($"Ogiltig ålder på besöjare {i + 1}.\n");
                result = builder.ToString();
                return false;
            }

            if (alder < 5 || alder > 100)
            {
                builder.Append($"Person {i + 1}: Gratis\n");
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

        builder.Append($"Antal personer: {input.Length}\n");
        builder.Append($"Totalkostnad: {total} kr\n");
        result = builder.ToString();
        return true;
    }

    public static bool UpprepaTioGanger(string input, out string result)
    {
        //Console.Write("Skriv en text: ");

        var builder = new StringBuilder();
        builder.Append('\n');

        for (int i = 1; i <= 10; i++)
        {
            builder.Append($"{i}. {input} \n");
        }

        result = builder.ToString();
        return true;
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

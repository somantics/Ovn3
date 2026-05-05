
using System;

namespace Ovn3;

public class CLIParser
{

    const int MaxAttempts = 5;
    
    public bool ParseAmount(string message, out int amount)
    {
        throw new NotImplementedException();
    }

    public bool ParseString(string message, out string input, int maxAttempts = MaxAttempts)
    {
        int attempts = 0;
        while (attempts < maxAttempts)
        {
            attempts++;
            string? rawInput = Console.ReadLine();
            if (rawInput is null) continue;

            input = rawInput;
            return true;
        }

        input = "";
        return false;
    }
}
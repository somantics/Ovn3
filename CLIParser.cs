
using System;

namespace Ovn3;

public class CLIParser
{
    private int maxAttempts = 5;
    public int MaxAttempts 
    {
        private get
        {
            return maxAttempts;
        }
        set
        {
            maxAttempts = value;
        }
    }
    
    public bool ParseAmount(out int amount)
    {
        throw new NotImplementedException();
    }

    public bool ParseString(out string input)
    {
        string? rawInput = Console.ReadLine();

        if (rawInput is not null)
        {
            input = rawInput;
            return true;
        }

        input = "";
        return false;
    }
}
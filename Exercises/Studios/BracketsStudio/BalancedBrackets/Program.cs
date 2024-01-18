using System;

namespace BalancedBracketsNS
{
    class Program
    {
        static void Main(string[] args)
        {
            BalancedBrackets.HasBalancedBrackets("[]");
            Console.WriteLine(BalancedBrackets.HasBalancedBrackets("[]"));
            BalancedBrackets.HasBalancedBrackets("][");
            Console.WriteLine(BalancedBrackets.HasBalancedBrackets("]["));
        }
    }
}

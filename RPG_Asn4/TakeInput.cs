using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Asn4
{
    public static class TakeInput
    {
        public static int GetMenuChoice()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    return choice;
                }
                Console.Write("Invalid input. Please enter a number: ");
            }
        }

        public static string GetPlayerName()
        {
            Console.Write("Enter your character's name: ");
            return Console.ReadLine() ?? "Unnamed Hero";
        }

    }
}

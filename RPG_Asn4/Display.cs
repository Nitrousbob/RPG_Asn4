namespace RPG_Asn4
{
    public static class Display
    {
        public static void ShowWelcomeMessage()
        {
            Console.Title = "RPG Game";
            Console.WriteLine("Welcome to the RPG Game!");
        }

        public static void TopMenu()
        {
            Console.WriteLine("1. Create Character");
            Console.WriteLine("2. Load Character");
            Console.WriteLine("3. Exit");
            Console.Write("Please select an option: ");
        }

        public static void Igm(string input)  // Igm stands for "In Game Message"
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{input}");
            Console.ResetColor();
        }
        //public static void NewGameMenu()
        //{
        //    Console.WriteLine("Starting a new game...");
        //    // Additional logic for starting a new game can be added here
        //}
    }
}

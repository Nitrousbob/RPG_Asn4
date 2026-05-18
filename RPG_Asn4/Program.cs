namespace RPG_Asn4
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Game g = new Game();
            Display.ShowWelcomeMessage();
            while (true)
            {
                Display.ShowMenuChoices(new string[] { "Create Character", "Load Character", "Start Game", "Exit" });
                switch (TakeInput.PromptIntInstant("Please select an option: ", 1, 2, 3, 4))
                {
                    case 1:
                        g.CreatePlayer();
                        break;
                    case 2:
                        g.LoadPlayer();
                        break;
                    case 3:
                        g.PlayGame();
                        break;
                    case 4:
                        Display.Igm("Exiting...");
                        return;
                    default:
                        Display.Error("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

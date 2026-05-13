namespace RPG_Asn4
{
    //im starting to notice my Command class needs to know about the Context of the game for different commands.
    public class Command
    {
        public void Look(List<Token> tokens, ComContext c)
        {
            if (c.CurrentTarget is Animal a)
            {
                Display.Action(a.GetDescription());
            }
            else if (c.CurrentTarget is Npc n)
            {
                Display.Action(n.GetDescription());
                string eyeBodyLanguage = HumanDialogFactory.NpcEyeBehavior(n);
                Display.Igm($"'{eyeBodyLanguage}'");
            }
            else
            {
                Console.WriteLine("There is nothing to look at.");
            }
        }

        public void Pet(List<Token> tokens, ComContext c)
        {
            if (c.CurrentTarget is IPettable pettable)
            {
                Display.Action($"You pet {pettable.Name}");
                //Display.Igm(pettable.getPetResponse);
            }
            else if (c.CurrentTarget is Npc n)
            {
                Display.Action($"You try to pet {n.Name}");
                Display.Igm($"{n.Name} doesn't seem to like that.");
            }
            else
            {
                Display.Igm("Very unusual, that's not something you can pet.");
            }

        }

        public void Slap(List<Token> tokens, ComContext c)
        {
            if (c.CurrentTarget is IInteractable interactable)
            {
                Display.Action($"You slap {interactable.Name}");
                Display.DarkAction($"{interactable.Name} looks at you with shock and anger.");
                interactable.BlockInteraction(3);  //mad for 3 turns, you can't interact with them for 3 turns.
                //remove interactable from npc while they are slapped, then add them back after a few turns to simulate them being mad at you for a while.
                //this was put into the Animals and Npcs OnInteract method, so they will stop interacting with you for a few turns after being slapped.
            }
            else
            {
                Console.WriteLine("That didn't just happen again!");
            }
        }

        public void Help(List<Token> tokens, ComContext c)
        {
            Display.Action("Available commands: ");
            Display.Bright("pet, look, help, exit, quit, bye, hit, slap");
        }

        public void Exit(List<Token> tokens, ComContext c)
        {
            Console.WriteLine("Exiting the program...");
            Environment.Exit(0);
        }
    }
}

namespace RPG_Asn4
{
    public class Npc : Actor, IInspectable
    {
        public bool HasEyes { get; private set; }
        public int GreetingCount { get; set; } = 0; // This property will track how many times the NPC has greeted the player.
        public Npc(string name, int health, bool hasEyes) : base(name, health)
        {
            HasEyes = hasEyes;
        }

        public string GetDescription()
        {
            return $"You see {Name}, a character in this world. But does {Name} have character?";
        }
        
        public override void OnInteract(Player player)
        {
            if (canInteract && GreetingCount < 5)
            {
                string greeting = HumanDialogFactory.GetRandomGreeting(this);
                Display.Igm($"\n{Name} says: '{greeting}'");
                GreetingCount++;
                
                HumanDialogFactory.Dialogger(this, player);  //Enters the dialog
            }
            else if (GreetingCount >= 5 && GreetingCount < 10)  //checks canInteract and if the npc has greeted the player 5 times
            {
                Display.Igm($"{Name} has greeted you enough times. Maybe try talking to them later.");
            }
            else
            {
                Display.Igm($"{Name} does not want to interact with you right now.");
            }
        }
                
    }
}

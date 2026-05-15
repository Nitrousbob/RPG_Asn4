namespace RPG_Asn4
{
    public class Animal : Actor, IInspectable, IPettable
    {
        public string Species { get; private set; }
        public bool HasEyes { get; private set; }
        public Player? CurrentPlayer { get; set; }

        public AnimalForagingState ForagingState {get; private set;}
        public AnimalSleepingState SleepingState {get; private set;}
        public AnimalInteractingState InteractingState {get; private set;}


        public Animal(string name, int health, string species, bool hasEyes) : base(name, health)
        {
            Species = species;
            HasEyes = hasEyes;

            ForagingState = new AnimalForagingState(this);
            SleepingState = new AnimalSleepingState(this);
            InteractingState = new AnimalInteractingState(this);

            StateMachine.Initialize(ForagingState);
        }

        public string GetDescription()
        {
            return $"You see {Name}, a {Species} in this world?";
        }

        public string GetPetResponse()
        {
            return $"{Name} seems to enjoy the petting.";
        }

        public override void OnInteract(Player player)
        {
            if (!canInteract)
            {
            Display.Igm($"{Name} signals that this is not a game.");
            return;
            }
                             
            CurrentPlayer = player;
            StateMachine.ChangeState(InteractingState);
            StateMachine.Update();
        }
    }
}

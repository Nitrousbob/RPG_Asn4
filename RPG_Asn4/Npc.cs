namespace RPG_Asn4
{
    public class Npc : Actor, IInspectable, ITalkable, IQuestionable
    {
        public Player? CurrentPlayer { get; set; }
        public NpcIdleState IdleState { get; private set; }
        public NpcTalkingState TalkingState { get; private set; }
        public NpcBusyState BusyState { get; private set; }

        //These are flavor text properties for Idle and Busy States
        public string IdleAction {get; set;}
        public string BusyStart {get; set;}
        public string BusyAction {get; set;}
        public string BusyEnd {get; set;}
        public string BusyRefusal {get; set;}

        public bool HasEyes { get; private set; }
        public int InteractionCount { get; set; } = 0; // This property will track how many times the NPC has greeted the player.
        public Npc(string name, int health, bool hasEyes) : base(name, health)
        {
            HasEyes = hasEyes;
            IdleState = new NpcIdleState(this);
            TalkingState = new NpcTalkingState(this);
            BusyState = new NpcBusyState(this);

            StateMachine.Initialize(IdleState);
        }

        public string GetDescription()
        {
            return $"You see {Name}, a character in this world. But does {Name} have character?";
        }
        
        public override void OnInteract(Player player)
        {
            if (!canInteract)
            {
                Display.Igm($"{Name} does not want to interact with you right now.");
                return;
            }
            
            if (StateMachine.CurrentState == BusyState)
            {
                Display.Igm($"{Name} {BusyRefusal}");
                return;
            }

            StartTalkingTo(player);
            StateMachine.Update();
        }

        public string GetTalkResponse()
        {
            InteractionCount++;
            if (InteractionCount < 5)
            {
                return "I came here to chew bubblegum and talk, and I'm all out of bubblegum.";
            }
            else
            {
                return "I'm all out of responses now too";
            }

            
        }
        public string GetQuestionResponse()
        {
            return "I'm afraid my responses are limited, you must ask the right question.";
        }

        public void StartTalkingTo(Player player)
        {
            CurrentPlayer = player;
            StateMachine.ChangeState(TalkingState);
        }

    }
}

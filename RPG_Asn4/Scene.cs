namespace RPG_Asn4
{
    public class Scene
    {
        public string Description { get; set; }
        public List<IInteractable> Locals { get; set; }

        public Scene(string description, List<IInteractable> locals)
        {
            Description = description;
            Locals = locals ?? new List<IInteractable>();
        }

        public void TickTurn()
        {
            foreach(IInteractable local in Locals)
            {
                local.TickInteractionCooldown();
            }
        }

        public void Describe(Player player)
        {
            Display.Igm(Description);
            InteractionHandler.InteractWith(Locals, player);
        }

        //define a starting scene with a description and some npcs to interact with

    }
}

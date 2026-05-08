namespace RPG_Asn4
{
    public class Animal : Actor, IInteractable, IInspectable, IPettable
    {
        public string Species { get; private set; }
        public bool HasEyes { get; private set; }
        public Animal(string name, int health, string species, bool hasEyes) : base(name, health)
        {
            Species = species;
            HasEyes = hasEyes;
        }

        public string Name { get; private set; }

        public string GetDescription()
        {
            return $"You see {Name}, a {Species} in this world?";
        }

        public string GetPetResponse()
        {
            return $"{Name} seems to enjoy the petting.";
        }

        public void OnInteract(Player player)
        {
            Display.Igm($"\n{Name} makes: '{AnimalDialogFactory.GetRandomAnimalNoise()}'");  //goofy because its random
            AnimalDialogFactory.Dialogger(this, player);  //Enters the dialog
        }
    }
}

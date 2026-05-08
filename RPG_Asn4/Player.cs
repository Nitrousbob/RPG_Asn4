namespace RPG_Asn4
{
    public class Player : Actor
    {
        
        public Player(string name, int health) : base(name, health)
        {
   
        }

        public override void OnInteract(Player player)
        {
            throw new NotImplementedException();
        }
    }
}

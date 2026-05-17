namespace RPG_Asn4
{
    public interface IReactable
    {
        string Name { get; }
        string OnAgitate();
        string OnLaughedAt();
        string OnFlirtedWith();
        string OnFartedAt();
    }
    
}
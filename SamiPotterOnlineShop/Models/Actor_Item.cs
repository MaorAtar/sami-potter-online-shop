namespace SamiPotterOnlineShop.Models
{
    public class Actor_Item
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}

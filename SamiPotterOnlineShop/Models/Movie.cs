using SamiPotterOnlineShop.Data.Base;
using SamiPotterOnlineShop.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamiPotterOnlineShop.Models
{
    public class Movie : Item, IEntityBase
    {
        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}

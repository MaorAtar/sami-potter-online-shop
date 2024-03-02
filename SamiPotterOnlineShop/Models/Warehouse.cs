using SamiPotterOnlineShop.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace SamiPotterOnlineShop.Models
{
    public class Warehouse : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Warehouse Logo")]
        [Required(ErrorMessage = "Warehouse Logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Warehouse Name")]
        [Required(ErrorMessage = "Warehouse Name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Warehouse Description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Movie>? Movies { get; set; }
    }
}

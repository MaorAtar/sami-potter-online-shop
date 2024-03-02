using SamiPotterOnlineShop.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace SamiPotterOnlineShop.Data.ViewModels
{
    public class NewMovieVM : NewItemVM
    {
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is required")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Movie producer is required")]
        public int ProducerId { get; set; }
    }
}
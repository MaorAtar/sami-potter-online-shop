using SamiPotterOnlineShop.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace SamiPotterOnlineShop.Data.ViewModels
{
    public class NewItemVM
    {
        public int Id { get; set; }

        [Display(Name = "Item name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Item description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The Price must positive")]
        public double Price { get; set; }

        public double OriginalPrice { get; set; }
        public bool OnSale { get; set; }

        [Display(Name = "Most Pouplar")]
        [Required(ErrorMessage = "Most Pouplar is required")]
        public MostPopularCategory MostPopular { get; set; }

        [Display(Name = "Item poster URL")]
        [Required(ErrorMessage = "Item poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Item start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Amount is required")]
        [Range(0, 100, ErrorMessage = "The Amount must be between 0-100")]
        public int Amount { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Item category is required")]
        public ItemCategory ItemCategory { get; set; }

        [Display(Name = "Select a format")]
        [Required(ErrorMessage = "Item format is required")]
        public FormatCategory FormatCategory { get; set; }

        [Display(Name = "Select a Warehouse")]
        [Required(ErrorMessage = "Item Warehouse is required")]
        public int WarehouseId { get; set; }

        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Item actor(s) is required")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Item producer is required")]
        public int ProducerId { get; set; }
    }
}

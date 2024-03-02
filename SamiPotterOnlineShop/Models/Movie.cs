﻿using SamiPotterOnlineShop.Data.Base;
using SamiPotterOnlineShop.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamiPotterOnlineShop.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public int Amount { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

        //Warehouse
        public int WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}

﻿using SamiPotterOnlineShop.Models;

namespace SamiPotterOnlineShop.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            Producers = new List<Producer>();
            Warehouses = new List<Warehouse>();
            Actors = new List<Actor>();
        }

        public List<Producer> Producers { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<Actor> Actors { get; set; }
    }
}

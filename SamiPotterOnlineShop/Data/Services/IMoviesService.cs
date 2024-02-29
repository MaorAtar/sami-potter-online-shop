﻿using SamiPotterOnlineShop.Data.Base;
using SamiPotterOnlineShop.Data.ViewModels;
using SamiPotterOnlineShop.Models;

namespace SamiPotterOnlineShop.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}

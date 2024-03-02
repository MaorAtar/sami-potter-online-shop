using SamiPotterOnlineShop.Data.Services;
using SamiPotterOnlineShop.Data.Static;
using SamiPotterOnlineShop.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SamiPotterOnlineShop.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Warehouse);
            return View(allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Warehouse);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) ||
                n.Description.ToLower().Contains(searchString.ToLower()) || n.Id.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Warehouses = new SelectList(movieDropdownsData.Warehouses, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
                ViewBag.Warehouses = new SelectList(movieDropdownsData.Warehouses, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDeatils = await _service.GetMovieByIdAsync(id);
            if (movieDeatils == null) return View("NotFound");
            var response = new NewMovieVM()
            {
                Id = movieDeatils.Id,
                Name = movieDeatils.Name,
                Description = movieDeatils.Description,
                Price = movieDeatils.Price,
                StartDate = movieDeatils.StartDate,
                Amount = movieDeatils.Amount,
                ImageURL = movieDeatils.ImageURL,
                MovieCategory = movieDeatils.MovieCategory,
                WarehouseId = movieDeatils.WarehouseId,
                ProducerId = movieDeatils.ProducerId,
                ActorIds = movieDeatils.Actors_Movies.Select(n => n.ActorId).ToList()
            };
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Warehouses = new SelectList(movieDropdownsData.Warehouses, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
                ViewBag.Warehouses = new SelectList(movieDropdownsData.Warehouses, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}

using SamiPotterOnlineShop.Data.Enums;
using SamiPotterOnlineShop.Data.Static;
using SamiPotterOnlineShop.Models;
using Microsoft.AspNetCore.Identity;

namespace SamiPotterOnlineShop.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Warehouse
                if (!context.Warehouses.Any())
                {
                    context.Warehouses.AddRange(new List<Warehouse>()
                    {
                        new Warehouse()
                        {
                            Name = "Warehouse 1",
                            Logo = "http://dotnethow.net/images/Warehouses/Warehouse-1.jpeg",
                            Description = "This is the description of the first Warehouse"
                        },
                        new Warehouse()
                        {
                            Name = "Warehouse 2",
                            Logo = "http://dotnethow.net/images/Warehouses/Warehouse-2.jpeg",
                            Description = "This is the description of the second Warehouse"
                        }
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Daniel Radcliffe",
                            Bio = "Daniel Jacob Radcliffe (born 23 July 1989).",
                            ProfilePictureURL = "https://resizing.flixster.com/rjR5PhclYP6M-GaGyqb-33tnuQQ=/218x280/v2/https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/233401_v9_bd.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Emma Watson",
                            Bio = "Emma Charlotte Duerre Watson (born 15 April 1990).",
                            ProfilePictureURL = "https://resizing.flixster.com/VBKpUG2HjHgSqCzCnfg7Dqj5K0Q=/218x280/v2/https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/247026_v9_bc.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Rupert Grint",
                            Bio = "Rupert Alexander Lloyd Grint (born 24 August 1988).",
                            ProfilePictureURL = "https://resizing.flixster.com/_GBmm2f38ZEtgKTMOW-q5UHeo8Y=/218x280/v2/https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/247025_v9_bc.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Robbie Coltrane",
                            Bio = "Anthony Robert McMillan (30 March 1950).",
                            ProfilePictureURL = "https://resizing.flixster.com/Rch2J71x5o0LIWYWJQJviCBVtIE=/218x280/v2/https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/71006_v9_ba.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Tom Felton",
                            Bio = "Thomas Andrew Felton (born 22 September 1987).",
                            ProfilePictureURL = "https://resizing.flixster.com/XjgrpG9Fdq39GpblkJEBF5BHn4Y=/218x280/v2/https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/171726_v9_bb.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "David Heyman",
                            Bio = "David Jonathan Heyman (born 26 July 1961).",
                            ProfilePictureURL = "https://resizing.flixster.com/-hx4AWoKceKQg4L3SdG5A03INtY=/218x280/v2/https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/376672_v9_bc.jpg"
                        },
                        new Producer()
                        {
                            FullName = "J. K. Rowling",
                            Bio = "Joanne Rowling (born 31 July 1965).",
                            ProfilePictureURL = "https://resizing.flixster.com/ua5GNEEA3IH23jrd7QglZI4M6s0=/218x280/v2/https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/174909_v9_bb.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Steve Kloves",
                            Bio = "Stephen Keith Kloves (born March 18, 1960).",
                            ProfilePictureURL = "https://resizing.flixster.com/sJrAbQvGtre2AP6TYXgcP1UyHlA=/218x280/v2/https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/201385_v9_ba.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Lionel Wigram",
                            Bio = "Lionel Nicholas Richard Wigram (born 22 December 1962).",
                            ProfilePictureURL = "https://resizing.flixster.com/5S0OeQRXoqNHV1ksleIiF6vtRU8=/218x280/v2/https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/438780_v9_ba.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "HARRY POTTER AND THE PHILOSOPHER’S STONE (2001)",
                            Description = "HARRY POTTER AND THE PHILOSOPHER’S STONE (2001) DESCRIPTION",
                            Price = 39.50,
                            ImageURL = "https://www.odeon.co.uk/media/dayfnwnw/wb_hp_1sht_1-8_ww-logo_st02_-1.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            WarehouseId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Movie,
                            Amount = 5
                        },
                        new Movie()
                        {
                            Name = "HARRY POTTER AND THE CHAMBER OF SECRETS (2002)",
                            Description = "HARRY POTTER AND THE CHAMBER OF SECRETS (2002) DESCRIPTION",
                            Price = 29.50,
                            ImageURL = "https://www.odeon.co.uk/media/jvtpdvvy/wb_hp_1sht_1-8_ww-logo_st02_2-1-1.jpg",
                            StartDate = DateTime.Now,
                            WarehouseId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Movie,
                            Amount = 3
                        },
                        new Movie()
                        {
                            Name = "HARRY POTTER AND THE PRISONER OF AZKABAN (2004)",
                            Description = "HARRY POTTER AND THE PRISONER OF AZKABAN (2004) DESCRIPTION",
                            Price = 39.50,
                            ImageURL = "https://www.odeon.co.uk/media/0pvbocpw/wb_hp_1sht_1-8_ww-logo_st02_4-1-1.jpg",
                            StartDate = DateTime.Now,
                            WarehouseId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Movie,
                            Amount = 5
                        },
                        new Movie()
                        {
                            Name = "HARRY POTTER AND THE GOBLET OF FIRE (2005)",
                            Description = "HARRY POTTER AND THE GOBLET OF FIRE (2005) DESCRIPTION",
                            Price = 39.50,
                            ImageURL = "https://www.odeon.co.uk/media/u54j5bmb/wb_hp_1sht_1-8_ww-logo_st02_6-1-1.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            WarehouseId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Movie,
                            Amount = 2
                        },
                        new Movie()
                        {
                            Name = "HARRY POTTER AND THE ORDER OF THE PHOENIX (2007)",
                            Description = "HARRY POTTER AND THE ORDER OF THE PHOENIX (2007) DESCRIPTION",
                            Price = 39.50,
                            ImageURL = "https://www.odeon.co.uk/media/skkl4k3t/wb_hp_1sht_1-8_ww-logo_st02_7-2-1.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            WarehouseId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Movie,
                            Amount = 0
                        },
                        new Movie()
                        {
                            Name = "HARRY POTTER AND THE HALF-BLOOD PRINCE (2009)",
                            Description = "HARRY POTTER AND THE HALF-BLOOD PRINCE (2009) DESCRIPTION",
                            Price = 39.50,
                            ImageURL = "https://www.odeon.co.uk/media/051fgvew/wb_hp_1sht_1-8_ww-logo_st02_8_500px-1-1.jpg",
                            StartDate = DateTime.Now.AddDays(3),
                            WarehouseId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Movie,
                            Amount = 6
                        },
                        new Movie()
                        {
                            Name = "HARRY POTTER AND THE DEATHLY HALLOWS PART 1",
                            Description = "HARRY POTTER AND THE DEATHLY HALLOWS PART 1 DESCRIPTION",
                            Price = 39.50,
                            ImageURL = "https://www.odeon.co.uk/media/y10f3l1t/wb_hp_1sht_1-8_ww-logo_st02_9-1-1.jpg",
                            StartDate = DateTime.Now.AddDays(2),
                            WarehouseId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Movie,
                            Amount = 6
                        },
                        new Movie()
                        {
                            Name = "HARRY POTTER AND THE DEATHLY HALLOWS PART 2",
                            Description = "HARRY POTTER AND THE DEATHLY HALLOWS PART 2 DESCRIPTION",
                            Price = 39.50,
                            ImageURL = "https://www.odeon.co.uk/media/ck4nivvy/wb_hp_1sht_1-8_ww-logo_st02_10-1-1.jpg",
                            StartDate = DateTime.Now.AddDays(-3),
                            WarehouseId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Movie,
                            Amount = 9
                        },
                        new Movie()
                        {
                            Name = "FANTASTIC BEASTS AND WHERE TO FIND THEM (2016)",
                            Description = "FANTASTIC BEASTS AND WHERE TO FIND THEM (2016) DESCRIPTION",
                            Price = 49.50,
                            ImageURL = "https://www.odeon.co.uk/media/h0lb4hw3/fantastic_beasts_and_where_to_find_them_ver2_xxlg-1.jpg",
                            StartDate = DateTime.Now.AddDays(1),
                            WarehouseId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Movie,
                            Amount = 2
                        },
                        new Movie()
                        {
                            Name = "FANTASTIC BEASTS: THE CRIMES OF GRINDELWALD (2018)",
                            Description = "FANTASTIC BEASTS: THE CRIMES OF GRINDELWALD (2018) DESCRIPTION",
                            Price = 39.50,
                            ImageURL = "https://www.odeon.co.uk/media/wcfpmqnl/fnbst2_tsr_cast_art_vert_dom_2764x4096-1.jpg",
                            StartDate = DateTime.Now.AddDays(4),
                            WarehouseId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Movie,
                            Amount = 6
                        },
                        new Movie()
                        {
                            Name = "FANTASTIC BEASTS: THE SECRETS OF DUMBLEDORE (2022)",
                            Description = "FANTASTIC BEASTS: THE SECRETS OF DUMBLEDORE (2022) DESCIRPTION",
                            Price = 39.50,
                            ImageURL = "https://www.odeon.co.uk/media/guwkmf3a/main-uk-one-sheet-1.jpg",
                            StartDate = DateTime.Now.AddDays(9),
                            WarehouseId = 1,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Movie,
                            Amount = 1
                        }
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 1
                        },
                         new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 1
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 2
                        },

                         new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },

                         new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 3
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 3
                        },
                         new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },

                         new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },
                         new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 4
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },

                         new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                         new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 6
                        },

                         new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                         new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 7
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 7
                        },

                         new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 7
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 7
                        },
                         new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 7
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 8
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 8
                        },

                         new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 8
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 8
                        },
                         new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 8
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 9
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 9
                        },

                         new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 9
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 9
                        },
                         new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 9
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 10
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 10
                        },

                         new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 10
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 10
                        },
                         new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 10
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 11
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 11
                        },

                         new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 11
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 11
                        },
                         new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 11
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
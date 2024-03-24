using SamiPotterOnlineShop.Data.Enums;
using SamiPotterOnlineShop.Data.Static;
using SamiPotterOnlineShop.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;
using SamiPotterOnlineShop.Data.ViewModels;

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
                            Name = "Warehouse KGC",
                            Logo = "https://t4.ftcdn.net/jpg/01/81/65/85/360_F_181658575_6gz3Gx96iRndmBtXv2llVsGOGsfdT1AP.jpg",
                            Description = "Warehouse located at Kiryat-Gat."
                        },
                        new Warehouse()
                        {
                            Name = "Warehouse B7",
                            Logo = "https://images.pexels.com/photos/4483610/pexels-photo-4483610.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                            Description = "Warehouse located at Beer-Sheva."
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
                //Items
                if (!context.Items.Any())
                {
                    context.Items.AddRange(new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Harry Potter and the Sorcerer's Stone",
                            Description = "Harry Potter and the Sorcerer's Stone (2001) Description",
                            Price = 39.50,
                            OriginalPrice = 39.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.Yes,
                            ImageURL = "https://media.themoviedb.org/t/p/w300_and_h450_bestv2/wuMc08IPKEatf9rnMNXvIDxqP4W.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            WarehouseId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Movie,
                            FormatCategory = FormatCategory.DVD,
                            Amount = 5
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Chamber of Secrets",
                            Description = "Harry Potter and the Chamber of Secrets (2002) Description",
                            Price = 29.50,
                            OriginalPrice = 29.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.Yes,
                            ImageURL = "https://media.themoviedb.org/t/p/w300_and_h450_bestv2/sdEOH0992YZ0QSxgXNIGLq1ToUi.jpg",
                            StartDate = DateTime.Now,
                            WarehouseId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Movie,
                            FormatCategory = FormatCategory.DVD,
                            Amount = 3
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Prisoner of Azkaban",
                            Description = "Harry Potter and the Prisoner of Azkaban (2004) Description",
                            Price = 39.50,
                            OriginalPrice = 39.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.Yes,
                            ImageURL = "https://media.themoviedb.org/t/p/w300_and_h450_bestv2/aWxwnYoe8p2d2fcxOqtvAtJ72Rw.jpg",
                            StartDate = DateTime.Now,
                            WarehouseId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Movie,
                            FormatCategory = FormatCategory.DVD,
                            Amount = 5
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Goblet of Fire",
                            Description = "Harry Potter and the Goblet of Fire (2005) Description",
                            Price = 39.50,
                            OriginalPrice = 39.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://media.themoviedb.org/t/p/w300_and_h450_bestv2/fECBtHlr0RB3foNHDiCBXeg9Bv9.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            WarehouseId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Movie,
                            FormatCategory = FormatCategory.BluRay,
                            Amount = 2
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Order of the Phoenix",
                            Description = "Harry Potter and the Order of the Phoenix (2007) Description",
                            Price = 39.50,
                            OriginalPrice = 39.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://media.themoviedb.org/t/p/w300_and_h450_bestv2/5aOyriWkPec0zUDxmHFP9qMmBaj.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            WarehouseId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Movie,
                            FormatCategory = FormatCategory.BluRay,
                            Amount = 0
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Half-Blood Prince",
                            Description = "Harry Potter and the Half-Blood Prince (2009) Description",
                            Price = 39.50,
                            OriginalPrice = 39.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://media.themoviedb.org/t/p/w300_and_h450_bestv2/z7uo9zmQdQwU5ZJHFpv2Upl30i1.jpg",
                            StartDate = DateTime.Now.AddDays(3),
                            WarehouseId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Movie,
                            FormatCategory = FormatCategory.BluRay,
                            Amount = 6
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Deathly Hallows: Part 1",
                            Description = "Harry Potter and the Deathly Hallows: Part 1 (2010) Description",
                            Price = 39.50,
                            OriginalPrice = 39.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://media.themoviedb.org/t/p/w300_and_h450_bestv2/iGoXIpQb7Pot00EEdwpwPajheZ5.jpg",
                            StartDate = DateTime.Now.AddDays(2),
                            WarehouseId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Movie,
                            FormatCategory = FormatCategory.FHD,
                            Amount = 6
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Deathly Hallows: Part 2",
                            Description = "Harry Potter and the Deathly Hallows: Part 2 (2011) Description",
                            Price = 39.50,
                            OriginalPrice = 39.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://media.themoviedb.org/t/p/w300_and_h450_bestv2/c54HpQmuwXjHq2C9wmoACjxoom3.jpg",
                            StartDate = DateTime.Now.AddDays(-3),
                            WarehouseId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Movie,
                            FormatCategory = FormatCategory.FHD,
                            Amount = 9
                        },
                        new Item()
                        {
                            Name = "Fantastic Beasts and Where to Find Them",
                            Description = "Fantastic Beasts and Where to Find Them (2016) Description",
                            Price = 49.50,
                            OriginalPrice = 49.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://media.themoviedb.org/t/p/w300_and_h450_bestv2/h6NYfVUyM6CDURtZSnBpz647Ldd.jpg",
                            StartDate = DateTime.Now.AddDays(1),
                            WarehouseId = 1,
                            ProducerId = 2,
                            ItemCategory = ItemCategory.Movie,
                            FormatCategory = FormatCategory.FHD,
                            Amount = 2
                        },
                        new Item()
                        {
                            Name = "Fantastic Beasts: The Crimes of Grindelwald",
                            Description = "Fantastic Beasts: The Crimes of Grindelwald (2018) Description",
                            Price = 39.50,
                            OriginalPrice = 39.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://media.themoviedb.org/t/p/w300_and_h450_bestv2/fMMrl8fD9gRCFJvsx0SuFwkEOop.jpg",
                            StartDate = DateTime.Now.AddDays(4),
                            WarehouseId = 1,
                            ProducerId = 3,
                            ItemCategory = ItemCategory.Movie,
                            FormatCategory = FormatCategory.FHD,
                            Amount = 6
                        },
                        new Item()
                        {
                            Name = "Fantastic Beasts: The Secrets of Dumbledore",
                            Description = "Fantastic Beasts: The Secrets of Dumbledore (2022) Description",
                            Price = 39.50,
                            OriginalPrice = 39.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://media.themoviedb.org/t/p/w300_and_h450_bestv2/jrgifaYeUtTnaH7NF5Drkgjg2MB.jpg",
                            StartDate = DateTime.Now.AddDays(9),
                            WarehouseId = 1,
                            ProducerId = 4,
                            ItemCategory = ItemCategory.Movie,
                            FormatCategory = FormatCategory.FHD,
                            Amount = 1
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Sorcerer's Stone",
                            Description = "Harry Potter and the Sorcerer's Stone (1999) Description",
                            Price = 24.90,
                            OriginalPrice = 24.90,
                            OnSale = false,
                            MostPopular = MostPopularCategory.Yes,
                            ImageURL = "https://images-evrit.yit.co.il/Images/Products/YediotMasters/HarryPottter1_Master.jpg",
                            StartDate = DateTime.Now.AddDays(9),
                            WarehouseId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Book,
                            FormatCategory = FormatCategory.HardBack,
                            Amount = 9
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Chamber of Secrets",
                            Description = "Harry Potter and the Chamber of Secrets (2000) Description",
                            Price = 29.50,
                            OriginalPrice = 29.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.Yes,
                            ImageURL = "https://images-evrit.yit.co.il/Images/Products/YediotMasters/HarryPottter2_Master.jpg",
                            StartDate = DateTime.Now,
                            WarehouseId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Book,
                            FormatCategory = FormatCategory.HardBack,
                            Amount = 3
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Prisoner of Azkaban",
                            Description = "Harry Potter and the Prisoner of Azkaban (2001) Description",
                            Price = 39.50,
                            OriginalPrice = 39.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.Yes,
                            ImageURL = "https://images-evrit.yit.co.il/Images/Products/YediotMasters/HarryPottter3_Master.jpg",
                            StartDate = DateTime.Now,
                            WarehouseId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Book,
                            FormatCategory = FormatCategory.HardBack,
                            Amount = 5
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Goblet of Fire",
                            Description = "Harry Potter and the Goblet of Fire (2001) Description",
                            Price = 39.50,
                            OriginalPrice = 39.50,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://images-evrit.yit.co.il/Images/Products/YediotMasters/HarryPottter4_Master.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            WarehouseId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Book,
                            FormatCategory = FormatCategory.HardBack,
                            Amount = 2
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Order of the Phoenix",
                            Description = "Harry Potter and the Order of the Phoenix (2003) Description",
                            Price = 24.90,
                            OriginalPrice = 24.90,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://images-evrit.yit.co.il/Images/Products/YediotMasters/HarryPottter5_Master.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            WarehouseId = 2,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Book,
                            FormatCategory = FormatCategory.SoftCover,
                            Amount = 5
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Half-Blood Prince",
                            Description = "Harry Potter and the Half-Blood Prince (2005) Description",
                            Price = 24.90,
                            OriginalPrice = 24.90,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://images-evrit.yit.co.il/Images/Products/YediotMasters/HarryPottter6_Master.jpg",
                            StartDate = DateTime.Now.AddDays(3),
                            WarehouseId = 2,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Book,
                            FormatCategory = FormatCategory.SoftCover,
                            Amount = 6
                        },
                        new Item()
                        {
                            Name = "Harry Potter and the Deathly Hallows",
                            Description = "Harry Potter and the Deathly Hallows (2007) Description",
                            Price = 24.90,
                            OriginalPrice = 24.90,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://images-evrit.yit.co.il/Images/Products/YediotMasters/HarryPottter7_Master.jpg",
                            StartDate = DateTime.Now.AddDays(2),
                            WarehouseId = 2,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Book,
                            FormatCategory = FormatCategory.SoftCover,
                            Amount = 6
                        },
                        new Item()
                        {
                            Name = "Hogwarts Legacy",
                            Description = "Hogwarts Legacy (2023) Description",
                            Price = 199.90,
                            OriginalPrice = 199.90,
                            OnSale = false,
                            MostPopular = MostPopularCategory.Yes,
                            ImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202208/0921/Ah7Ar9MU0r1BBlzAUflmhyQP.png",
                            StartDate = DateTime.Now.AddDays(3),
                            WarehouseId = 2,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.VideoGame,
                            FormatCategory = FormatCategory.PS5,
                            Amount = 9
                        },
                        new Item()
                        {
                            Name = "LEGO Harry Potter: Years 5-7 ",
                            Description = "LEGO Harry Potter: Years 5-7 (2012) Description",
                            Price = 19.90,
                            OriginalPrice = 19.90,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://assets-prd.ignimgs.com/2022/01/07/lego-harry-potter-years-5-7-button-1641594071231.jpg",
                            StartDate = DateTime.Now.AddDays(2),
                            WarehouseId = 2,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.VideoGame,
                            FormatCategory = FormatCategory.PC,
                            Amount = 2
                        },
                        new Item()
                        {
                            Name = "Harry Potter's Wand",
                            Description = "The wand that chose Harry Potter, the Boy Who Lived, when he visited Ollivanders Wand shop at 11 years of age. Take home one of the most iconic and recognisable props from the Harry Potter film series, this high-quality replica of Harry Potter's wand.",
                            Price = 149.99,
                            OriginalPrice = 149.99,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://shop.universalorlando.com/merchimages/p-interactive-harry-potter-wand-1279648.jpg",
                            StartDate = DateTime.Now.AddDays(2),
                            WarehouseId = 2,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Wand,
                            Amount = 5
                        },
                        new Item()
                        {
                            Name = "Ron Weasly's Wand",
                            Description = "The wand of Ron Weasley, founding member of Dumbledore’s Army, Gryffindor Keeper and best friend to Harry Potter and Hermione Granger.",
                            Price = 149.99,
                            OriginalPrice = 149.99,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://shop.universalorlando.com/merchimages/p-interactive-ron-weasley-wand-1285935.jpg",
                            StartDate = DateTime.Now.AddDays(2),
                            WarehouseId = 2,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Wand,
                            Amount = 5
                        },
                        new Item()
                        {
                            Name = "Hermione Granger's Wand",
                            Description = "Take home the wand of Hermione Granger, founding member of Dumbledore’s Army, best friend to Ron and Harry and often called the brightest witch of her age.",
                            Price = 149.99,
                            OriginalPrice = 149.99,
                            OnSale = false,
                            MostPopular = MostPopularCategory.No,
                            ImageURL = "https://shop.universalorlando.com/merchimages/p-interactive-hermione-granger-wand-1279649.jpg",
                            StartDate = DateTime.Now.AddDays(2),
                            WarehouseId = 2,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Wand,
                            Amount = 5
                        },

                    });
                    context.SaveChanges();
                }

                if (!context.Actors_Items.Any())
                {
                    context.Actors_Items.AddRange(new List<Actor_Item>()
                    {
                        new Actor_Item()
                        {
                            ActorId = 1,
                            ItemId = 1
                        },
                        new Actor_Item()
                        {
                            ActorId = 2,
                            ItemId = 1
                        },

                         new Actor_Item()
                        {
                            ActorId = 3,
                            ItemId = 1
                        },
                         new Actor_Item()
                        {
                            ActorId = 4,
                            ItemId = 1
                        },
                         new Actor_Item()
                        {
                            ActorId = 5,
                            ItemId = 1
                        },

                        new Actor_Item()
                        {
                            ActorId = 1,
                            ItemId = 2
                        },
                        new Actor_Item()
                        {
                            ActorId = 2,
                            ItemId = 2
                        },

                         new Actor_Item()
                        {
                            ActorId = 3,
                            ItemId = 2
                        },
                         new Actor_Item()
                        {
                            ActorId = 4,
                            ItemId = 2
                        },
                         new Actor_Item()
                        {
                            ActorId = 5,
                            ItemId = 2
                        },

                        new Actor_Item()
                        {
                            ActorId = 1,
                            ItemId = 3
                        },
                        new Actor_Item()
                        {
                            ActorId = 2,
                            ItemId = 3
                        },

                         new Actor_Item()
                        {
                            ActorId = 3,
                            ItemId = 3
                        },
                         new Actor_Item()
                        {
                            ActorId = 4,
                            ItemId = 3
                        },
                         new Actor_Item()
                        {
                            ActorId = 5,
                            ItemId = 3
                        },

                        new Actor_Item()
                        {
                            ActorId = 1,
                            ItemId = 4
                        },
                        new Actor_Item()
                        {
                            ActorId = 2,
                            ItemId = 4
                        },

                         new Actor_Item()
                        {
                            ActorId = 3,
                            ItemId = 4
                        },
                         new Actor_Item()
                        {
                            ActorId = 4,
                            ItemId = 4
                        },
                         new Actor_Item()
                        {
                            ActorId = 5,
                            ItemId = 4
                        },

                        new Actor_Item()
                        {
                            ActorId = 1,
                            ItemId = 5
                        },
                        new Actor_Item()
                        {
                            ActorId = 2,
                            ItemId = 5
                        },

                         new Actor_Item()
                        {
                            ActorId = 3,
                            ItemId = 5
                        },
                         new Actor_Item()
                        {
                            ActorId = 4,
                            ItemId = 5
                        },
                         new Actor_Item()
                        {
                            ActorId = 5,
                            ItemId = 5
                        },

                        new Actor_Item()
                        {
                            ActorId = 1,
                            ItemId = 6
                        },
                        new Actor_Item()
                        {
                            ActorId = 2,
                            ItemId = 6
                        },

                         new Actor_Item()
                        {
                            ActorId = 3,
                            ItemId = 6
                        },
                         new Actor_Item()
                        {
                            ActorId = 4,
                            ItemId = 6
                        },
                         new Actor_Item()
                        {
                            ActorId = 5,
                            ItemId = 6
                        },

                        new Actor_Item()
                        {
                            ActorId = 1,
                            ItemId = 7
                        },
                        new Actor_Item()
                        {
                            ActorId = 2,
                            ItemId = 7
                        },

                         new Actor_Item()
                        {
                            ActorId = 3,
                            ItemId = 7
                        },
                         new Actor_Item()
                        {
                            ActorId = 4,
                            ItemId = 7
                        },
                         new Actor_Item()
                        {
                            ActorId = 5,
                            ItemId = 7
                        },

                        new Actor_Item()
                        {
                            ActorId = 1,
                            ItemId = 8
                        },
                        new Actor_Item()
                        {
                            ActorId = 2,
                            ItemId = 8
                        },

                         new Actor_Item()
                        {
                            ActorId = 3,
                            ItemId = 8
                        },
                         new Actor_Item()
                        {
                            ActorId = 4,
                            ItemId = 8
                        },
                         new Actor_Item()
                        {
                            ActorId = 5,
                            ItemId = 8
                        },

                        new Actor_Item()
                        {
                            ActorId = 1,
                            ItemId = 9
                        },
                        new Actor_Item()
                        {
                            ActorId = 2,
                            ItemId = 9
                        },

                         new Actor_Item()
                        {
                            ActorId = 3,
                            ItemId = 9
                        },
                         new Actor_Item()
                        {
                            ActorId = 4,
                            ItemId = 9
                        },
                         new Actor_Item()
                        {
                            ActorId = 5,
                            ItemId = 9
                        },

                        new Actor_Item()
                        {
                            ActorId = 1,
                            ItemId = 10
                        },
                        new Actor_Item()
                        {
                            ActorId = 2,
                            ItemId = 10
                        },

                         new Actor_Item()
                        {
                            ActorId = 3,
                            ItemId = 10
                        },
                         new Actor_Item()
                        {
                            ActorId = 4,
                            ItemId = 10
                        },
                         new Actor_Item()
                        {
                            ActorId = 5,
                            ItemId = 10
                        },

                        new Actor_Item()
                        {
                            ActorId = 1,
                            ItemId = 11
                        },
                        new Actor_Item()
                        {
                            ActorId = 2,
                            ItemId = 11
                        },

                         new Actor_Item()
                        {
                            ActorId = 3,
                            ItemId = 11
                        },
                         new Actor_Item()
                        {
                            ActorId = 4,
                            ItemId = 11
                        },
                         new Actor_Item()
                        {
                            ActorId = 5,
                            ItemId = 11
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
                string adminUserEmail = "admin@gmail.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                var encryptedCreditCardNumber = EncryptString("470132221111123412/2026837", "samipotterencryption1234");
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        CreditCardNumber = encryptedCreditCardNumber,
                        Notified = false
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin123!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@gmail.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        CreditCardNumber = encryptedCreditCardNumber,
                        Notified = false
                    };
                    await userManager.CreateAsync(newAppUser, "User123!");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }

        private static string EncryptString(string text, string password)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(password);
                aesAlg.IV = new byte[16];
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(text);
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
    }
}
using eTickets.Data.Statics;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;

namespace eTickets.Data
{
    public class ApplicationDbInitializer
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                // Populate the database tables
                if (!context.Actors.Any())
                {
                    await context.Actors.AddRangeAsync(new List<Actor>()
                    {
                        new Actor
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });

                    await context.SaveChangesAsync();
                }

                if (!context.Producers.Any())
                {
                    await context.Producers.AddRangeAsync(new List<Producer>()
                    {
                        new Producer
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });

                    await context.SaveChangesAsync();
                }

                if (!context.Cinemas.Any())
                {
                    await context.AddRangeAsync(new List<Cinema>()
                    {
                        new Cinema
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        }
                    });

                    await context.SaveChangesAsync();
                }

                if (!context.MovieCategories.Any())
                {
                    await context.MovieCategories.AddRangeAsync(new List<MovieCategory>()
                    {
                        new MovieCategory
                        {
                            Name = "Action",
                            Description = "Movies in the action genre are defined by risk and stakes. While many movies may feature an action sequence, to be appropriately categorized inside the action genre, the bulk of the content must be action-oriented, including fight scenes, stunts, car chases, and general danger."
                        },
                        new MovieCategory
                        {
                            Name = "Animation",
                            Description = "The animation genre is defined by inanimate objects being manipulated to appear as though they are living. This can be done in many different ways and can incorporate any other genre and sub-genre on this list. For more info on animation, you can dive deeper on the types of animation or see our list of the best animated movies of all time."
                        },
                        new MovieCategory
                        {
                            Name = "Comedy",
                            Description = "The comedy genre is defined by events that are intended to make someone laugh, no matter if the story is macabre, droll, or zany. Comedy can be found in most movies, but if the majority of the film is intended to be a comedy you may safely place it in this genre. The best comedy movies range throughout this entire spectrum of humor."
                        },
                        new MovieCategory
                        {
                            Name = "Crime",
                            Description = "The crime genre deals with both sides of the criminal justice system but does not focus on legislative matters or civil suits and legal actions. The best crime movies often occupy moral gray areas where heroes and villains are much harder to define."
                        },
                        new MovieCategory
                        {
                            Name = "Drama",
                            Description = "The drama genre is defined by conflict and often looks to reality rather than sensationalism. Emotions and intense situations are the focus, but where other genres might use unique or exciting moments to create a feeling, movies in the drama genre focus on common occurrences. Drama is a very broad category and untethered to any era — from movies based on Shakespeare to contemporary narratives."
                        },
                        new MovieCategory
                        {
                            Name = "Fantasy",
                            Description = "The fantasy genre is defined by both circumstance and setting inside a fictional universe with an unrealistic set of natural laws. The possibilities of fantasy are nearly endless, but the movies will often be inspired by or incorporate human myths."
                        },
                        new MovieCategory
                        {
                            Name = "Historical",
                            Description = "The historical genre can be split into two sections. One deals with accurate representations of historical accounts which can include biographies, autobiographies, and memoirs. The other section is made up of fictional movies that are placed inside an accurate depiction of a historical setting. \r\n\r\nThe accuracy of a historical story is measured against historical accounts, not fact, as there can never be a perfectly factual account of any event without first-hand experience."
                        },
                        new MovieCategory
                        {
                            Name = "Horror",
                            Description = "The horror genre is centered upon depicting terrifying or macabre events for the sake of entertainment. A thriller might tease the possibility of a terrible event, whereas a horror film will deliver all throughout the film. The best horror movies are designed to get the heart pumping and to show us a glimpse of the unknown."
                        },
                        new MovieCategory
                        {
                            Name = "Romance",
                            Description = "The romance genre is defined by intimate relationships. Sometimes these movies can have a darker twist, but the idea is to lean on the natural conflict derived from the pursuit of intimacy and love."
                        },
                        new MovieCategory
                        {
                            Name = "Science Fiction",
                            Description = "Science fiction movies are defined by a mixture of speculation and science. While fantasy will explain through or make use of magic and mysticism, science fiction will use the changes and trajectory of technology and science. Science fiction will often incorporate space, biology, energy, time, and any other observable science."
                        },
                        new MovieCategory
                        {
                            Name = "Thriller",
                            Description = "A thriller story is mostly about the emotional purpose, which is to elicit strong emotions, mostly dealing with generating suspense and anxiety. No matter what the specific plot, the best thrillers get your heart racing."
                        },
                        new MovieCategory
                        {
                            Name = "Western",
                            Description = "Westerns are defined by their setting and time period. The story needs to take place in the American West, which begins as far east as Missouri and extends to the Pacific ocean. They’re set during the 19th century, and will often feature horse riding, military expansion, violent and non-violent interaction with Native American tribes, the creation of railways, gunfights, and technology created during the industrial revolution."
                        },
                        new MovieCategory
                        {
                            Name = "Documentary",
                            Description = "A documentary film purports to present factual information about the world outside the film."
                        }
                    });
                    await context.SaveChangesAsync();
                }

                if (!context.Movies.Any())
                {
                    await context.Movies.AddRangeAsync(new List<Movie>()
                    {
                        new Movie
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50M,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategoryId = 13
                        },
                        new Movie
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50M,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategoryId = 1
                        },
                        new Movie
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 29.50M,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategoryId = 8
                        },
                        new Movie
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 29.50M,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategoryId = 13
                        },
                        new Movie
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 29.50M,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategoryId = 2
                        },
                        new Movie
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 29.50M,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategoryId = 5
                        }
                    });
                    await context.SaveChangesAsync();
                }

                if (!context.ActorsMovies.Any())
                {
                    await context.ActorsMovies.AddRangeAsync(new List<ActorMovie>()
                    {
                        new ActorMovie
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new ActorMovie
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new ActorMovie
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new ActorMovie
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new ActorMovie
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new ActorMovie
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new ActorMovie
                        {
                            ActorId = 5,
                            MovieId = 3
                        },

                        new ActorMovie
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new ActorMovie
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new ActorMovie
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new ActorMovie
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new ActorMovie
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new ActorMovie
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new ActorMovie
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new ActorMovie
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new ActorMovie
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new ActorMovie
                        {
                            ActorId = 5,
                            MovieId = 6
                        }
                    });

                    await context.SaveChangesAsync();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Roles
                if (!await roleManager.RoleExistsAsync(UserRole.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
                }

                if (!await roleManager.RoleExistsAsync(UserRole.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRole.User));
                }

                // Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminEmail = "admin@etickets.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser is null)
                {
                    adminUser = new ApplicationUser
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(adminUser, "Pass123!");
                    await userManager.AddToRoleAsync(adminUser, UserRole.Admin);
                }

                string userEmail = "user@etickets.com";
                var appUser = await userManager.FindByEmailAsync(userEmail);
                if (appUser is null)
                {
                    appUser = new ApplicationUser
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = userEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(appUser, "Pass123!");
                    await userManager.AddToRoleAsync(appUser, UserRole.User);
                }
            }
        }
    }
}

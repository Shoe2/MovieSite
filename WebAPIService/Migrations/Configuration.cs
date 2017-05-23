namespace WebAPIService.Migrations
{
    using MovieSite.Models;
    using MovieSite;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static MovieSite.GenreDefinitions;
    using System.Collections.Generic;
    using System.Globalization;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPIService.Models.MovieServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAPIService.Models.MovieServiceContext context)
        {
            context.Directors.AddOrUpdate(x => x.Id,
      new Models.Director() { ID = 1, DirectorFirstName = "Stephen", DirectorLastName = "Speilburg" },

      );

            context.Movies.AddOrUpdate(x => x.Id,
                new Movie()
                {
                    ID = 1,
                    Title = "Jaws",
                    DateReleased = DateTime.ParseExact("06/20/1975", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    DirectorID = 1,
                    Length = 90,
                    MainGenre = Genre.Horror,
                    SubGenre = new List<SubGenre>(new SubGenre[] { SubGenre.Thriller, SubGenre.GuyFilms }),
                    Description = "A giant great white shark arrives on the shores of a New England beach resort and wreaks havoc with bloody attacks on swimmers, until a local sheriff teams up with a marine biologist and an old seafarer to hunt the monster down."
                },
                new Movie()
                {
                    ID = 1,
                    Title = "Jurrassic Park",
                    DateReleased = DateTime.ParseExact("06/11/1993", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    DirectorID = 1,
                    Length = 127,
                    MainGenre = Genre.Adventure,
                    SubGenre = new List<SubGenre>(new SubGenre[] { SubGenre.Thriller, SubGenre.GuyFilms }),
                    Description = "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok."

                });
        }
    }
}

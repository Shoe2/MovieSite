using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static MovieSite.GenreDefinitions;
using System.Runtime.Remoting.Contexts;

namespace MovieSite
{

    public class Movie
    {
        public string Title { get; set; }
        public Genre MainGenre { get; set; }
        public List<SubGenre> SubGenre { get; set; }
        public Director Director { get; set; }
        public DateTime DateReleased { get; set; }
        public int Length { get; set; }
        public string Description { get; set; }
    }

    public class Director
    {

        public string DirectorFirstName { get; set; }
        public string DirectorLastName { get; set; }

    }

    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
    }

    class AccessDB
    {

        public static void AddToDB ()
        {
            Movie newMovie = new Movie();
            newMovie.Title = "test";
            newMovie.MainGenre = Genre.Horror;
            newMovie.SubGenre.Add(SubGenre.ChickFlick);
            newMovie.DateReleased = DateTime.Now;
            newMovie.Length = 66;
            newMovie.Description = "FUUUUUUU";
                        
            using (var db = new MovieContext())
            {
                db.Movies.Add(newMovie);

                
                db.Directors.Add(newMovie.Director);
                db.SaveChanges();
            }
        }

    }
    
}

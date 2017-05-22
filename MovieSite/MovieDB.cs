using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static MovieSite.GenreDefinitions;
using System.Runtime.Remoting.Contexts;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;

namespace MovieSite
{

    public class Movie
    {
        public Movie(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jMovie = jObject["Movie"];
            Title = (string)jMovie["Title"];

            string genreString = (string)jMovie["Genre"];
            MainGenre = (Genre) Enum.Parse(typeof(Genre), genreString);

            //Subgenre list
            SubGenre = new List<SubGenre>
            {

            };
            foreach (string sub in jMovie["SubGenre"])
            {
                SubGenre.Add((SubGenre) Enum.Parse(typeof(SubGenre), sub));
            }
            

            //Director takes multiple lines to turn a string into a database entry 
            //TODO: Account for same director on multiple movies
            var directorString = (string)jMovie["Director"];
            Director.DirectorFirstName = directorString.Split(' ')[0];
            Director.DirectorLastName = directorString.Split(' ')[1];

            DateReleased = (DateTime)jMovie["DateReleased"];
            Length = (int)jMovie["Length"];
            Description = (string)jMovie["Description"];
        
        }
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

        public static void AddToDB(string data)
        {
            Movie newMovie = new Movie(data);

            using (var db = new MovieContext())
            {
                db.Movies.Add(newMovie);
                db.Directors.Add(newMovie.Director);
                db.SaveChanges();
            }
        }

    }
    
}

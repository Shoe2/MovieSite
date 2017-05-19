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
            MainGenre = Enum.Parse(Genre, jMovie["Genre"]);
            //SubGenre = ;
            //Director = jUser["players"].ToArray();
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
            Movie.Movie(data);

            using (var db = new MovieContext())
            {
                db.Movies.Add();

                
                db.Directors.Add(newMovie.Director);
                db.SaveChanges();
            }
        }

    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static MovieSite.GenreDefinitions;

namespace MovieSite
{
   
        public class Movie
        {
            public string Title { get; set; }
            public Genre MainGenre { get; set; }
            public SubGenre SubGenre { get; set; }
            public string DirectorName { get; set; }
            public DateTime DateReleased { get; set; }
            public int Length { get; set; }
            public string Description { get; set; }
        }
    
}

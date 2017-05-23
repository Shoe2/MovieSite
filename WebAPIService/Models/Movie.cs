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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPIService.Models;

namespace MovieSite.Models
{

    public class Movie
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public Genre MainGenre { get; set; }
        public List<SubGenre> SubGenre { get; set; }
        public int DirectorID { get; set; }
        public Director Director { get; set; }
        public DateTime DateReleased { get; set; }
        public int Length { get; set; }
        public string Description { get; set; }
    }

    
}



    
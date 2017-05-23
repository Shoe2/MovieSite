using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIService.Models
{
    public class MovieDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string MainGenre { get; set; }
        public string SubGenre { get; set; }
        public string Director { get; set; }
        public string DateReleased { get; set; }
        public int Length { get; set; }
        public string Description { get; set; }
    }
}
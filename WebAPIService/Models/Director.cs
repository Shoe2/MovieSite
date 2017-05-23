using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAPIService.Models
{
    public class Director
    {
        public int ID { get; set; }
        public string DirectorFirstName { get; set; }
        public string DirectorLastName { get; set; }
      
    }
}
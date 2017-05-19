using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieSite;
using System.Data.Entity;

namespace WebAPIService.Controllers
{
    public class ValuesController : ApiController
    {
        // GET all movies to populate app
        public IEnumerable<Movie> Get()
        {            
            
                using (var db = new MovieContext())
                {
                var MoviesList = from m in db.Movies
                                 select m;
                return MoviesList;
                }
                
            
        }

        // POST added movie to DB
        public void Post([FromBody]string value)
        {
            AddToDB();
        }

        
    }
}

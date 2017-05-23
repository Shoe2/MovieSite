using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MovieSite.Models;
using WebAPIService.Models;

namespace WebAPIService.Controllers
{
    public class MoviesController : ApiController
    {
        private MovieServiceContext db = new MovieServiceContext();

        // GET: api/Movies
        public IQueryable<MovieDTO> GetMovies()
        {
            var movies = from m in db.Movies
                         select new MovieDTO()
                         {
                             ID = m.ID,
                             Title = m.Title,
                             MainGenre = m.MainGenre.ToString(),
                             Director = m.Director.Name,
                             DateReleased = m.DateReleased.ToString(),
                             Length = m.Length,
                             Description = m.Description,
                             SubGenre = m.SubGenre.ToString()

                };


            return movies;
        }

        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movie);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = movie.ID }, movie);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> DeleteMovie(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            await db.SaveChangesAsync();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
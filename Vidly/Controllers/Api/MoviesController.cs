using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        
        }





        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult GetMovies(string query = null)
        {

         

            var movieQuery = _context.Movies.Include(m => m.Genres).Where(m=>m.NumberAvailable>0);


            if (!string.IsNullOrEmpty(query))
            {
                movieQuery = movieQuery.Where(m => m.Name.Contains(query));


            }
             
           




            var movieDtos = movieQuery
                            .ToList()
                            .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);

        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult GetMovie(int id)
        {

            var movie = _context.Movies.SingleOrDefault(m => m.Id ==id);

            if (movie==null)
            {
                return NotFound();
            }


            return Ok(Mapper.Map<Movie, MovieDto>(movie));

        }



        [Authorize(Roles =RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);

            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }




        [Authorize(Roles =RoleName.CanManageMovies)]
        [HttpPut]
         public IHttpActionResult UpdateMovie(int id,MovieDto movieDto)
         {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb==null)
            {
                return NotFound();
            }


            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();


         }


        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb==null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);

            _context.SaveChanges();

            return Ok();


        }













    }
}

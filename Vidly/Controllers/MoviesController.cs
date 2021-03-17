using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        // GET: Movies

        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {

            if (User.IsInRole(RoleName.CanManageMovies))
            {

                return View("List");

            }

            return View("ReadOnlyList");

        }




        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genres).SingleOrDefault(mv => mv.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }


        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm",viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
           if(!ModelState.IsValid)
            {
                

                var viewModel = new MovieFormViewModel(movie)
                {

                    
                    Genres = _context.Genres.ToList()
                };


                return View("MovieForm", viewModel);
             }

            if (movie.Id==0)
            {
                movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = movie.NumberInStock;
                _context.Movies.Add(movie);

            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenresId = movie.GenresId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.NumberAvailable = movie.NumberInStock;
               



            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies"); 

        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);


            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
               
                Genres = _context.Genres.ToList()

            };




            return View("MovieForm", viewModel);
        }




    }
}
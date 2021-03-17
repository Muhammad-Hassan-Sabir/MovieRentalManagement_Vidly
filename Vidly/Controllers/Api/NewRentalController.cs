using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalController : ApiController
    {

        ApplicationDbContext _context;
        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {

            var customerInDb = _context.Customer.Single(c => c.Id == newRental.CustomerId);

            var moviesInDb = _context.Movies.Where(m =>newRental.MoviesIds.Any(m1=>m1==m.Id));

            foreach (var movie in moviesInDb)
            {
                if (movie.NumberAvailable==0)
                {
                    return BadRequest("Movie Is Not Available");
                }
                movie.NumberAvailable--;
                var newrental = new Rental
                {
                    Customer = customerInDb,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(newrental);

                


            }
            _context.SaveChanges();


            return Ok();
        }






    }
}
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly_New.Dtos;
using Vidly_New.Models;

namespace Vidly_New.Controllers.API {
    public class RentalController: ApiController {

        private ApplicationDbContext context;

        public RentalController() {
            context = new ApplicationDbContext();
        }

        // GET api/rental
        public IHttpActionResult GetRentalsByCustomerId(int id) {
            return Ok();
        }

        public IHttpActionResult GetRentals() {
            return Ok();
        }

        // GET api/rental/5
        public IHttpActionResult GetRental(int id) {
            return Ok();
        }

        // POST api/rental
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto newRental) {
            var customer = context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if(customer == null || newRental.MovieIds.Count == 0) return NotFound();

            var movies = context.Movies.Where(m => newRental.MovieIds.Contains(m.Id));

            foreach(var movie in movies) {
                Rental rental = new Rental(customer, movie);
                //rental.Id = movie.Id;
                context.Rentals.Add(rental);
            
            }
            context.SaveChanges();
            return Ok();
        }
    }
}
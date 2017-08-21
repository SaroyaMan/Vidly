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

            //if(newRental.MovieIds.Count == 0)
            //    return BadRequest("No Movie Ids have been given.");

            //var customer = context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            var customer = context.Customers.Single(c => c.Id == newRental.CustomerId);

            //if(customer == null)
            //    return BadRequest("CustomerId is not valid.");

            var movies = context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            //if(movies.Count != newRental.MovieIds.Count)
            //    return BadRequest("One or more MovieIds are invalid.");

            foreach(var movie in movies) {
                if(movie.Available == 0) {
                    return BadRequest("Movie is not available.");
                }

                Rental rental = new Rental(customer, movie);

                context.Rentals.Add(rental);
            
            }
            context.SaveChanges();
            return Ok();
        }
    }
}
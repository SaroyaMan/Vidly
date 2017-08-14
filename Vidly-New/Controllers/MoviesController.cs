using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly_New.Models;
using System.Data.Entity;
using Vidly_New.ViewModels;
using AutoMapper;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext context;

        public MoviesController() {
            context = new ApplicationDbContext();
            Mapper.Initialize(cfg => cfg.CreateMap<Customer, Customer>());
        }

        protected override void Dispose(bool disposing) {
            context.Dispose();
        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer> {
                new Customer {Name = "Yoav Saroya"},
                new Customer {Name = "Amit Shmuel"}
            };
            var viewModel = new RandomMovieViewModel {
                Movies = { movie },
                Customers = customers
            };

            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model = movie;

            return View(viewModel);


            //var movie = new Movie();
            //movie.Name = "Shrek!";

            // can also be called: return new ViewResult(movie)
            //return View(movie);
            //return Content("<h1>Hello World</h1>");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { pages = 1, sortBy = "name" });
        }

        public ActionResult Details(int id) {
            var movie = context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if(movie == null) return HttpNotFound();
            return View(movie);
        }

        // movies
        public ActionResult Index() {

            var movies = context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        //Code Snippet: mvc4 + TAB + TAB = Create a quick action
        //this attribute enables to change the method name free
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month) {
            return Content($"{year}/{month}");
        }

        public ActionResult New() {
            var genres = context.Genres.ToList();
            var viewModel = new MovieFormViewModel() {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id) {
            var movie = context.Movies.SingleOrDefault(c => c.Id == id);
            if(movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel() {
                Movie = movie,
                Genres = context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie) {
            if(movie.Id == 0) {
                context.Movies.Add(movie);
            }
            else {
                var customerInDb = context.Customers.Single(c => c.Id == movie.Id);
                Mapper.Map(movie, customerInDb);
            }
            context.SaveChanges();  //Save and commit it in the Database (Like a Transaction)
            return RedirectToAction("Index", "Movies");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> customers = new List<Customer>() {
            new Customer() {Id = 0, Name = "Yoav Saroya"},
            new Customer() {Id = 1, Name = "Amit Shmuel"}
        };


        // GET: Customers
        public ActionResult Index() {
            return View(new RandomMovieViewModel() { Customers = customers });
        }

        public ActionResult Details(int id) {
            if(id < 0 || id >= customers.Count) {
                return HttpNotFound();
            }
            return View(customers[id]);
        }
    }
}
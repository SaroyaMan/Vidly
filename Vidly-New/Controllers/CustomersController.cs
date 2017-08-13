using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly_New.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext context;

        public CustomersController() {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            context.Dispose();
        }


        // GET: Customers
        public ActionResult Index() {
            var customers = context.Customers.Include( c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id) {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null) return HttpNotFound();
            return View(customer);
        }
    }
}
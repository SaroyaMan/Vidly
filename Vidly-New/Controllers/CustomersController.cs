using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly_New.ViewModels;
using Vidly.Models;
using AutoMapper;
using Vidly_New.Models;

namespace Vidly.Controllers
{
    //[Authorize]       //Apply authorization to this controller
    public class CustomersController : Controller
    {
        private ApplicationDbContext context;

        public CustomersController() {
            context = new ApplicationDbContext();
            Mapper.Initialize(cfg => cfg.CreateMap<Customer, Customer>());
        }

        protected override void Dispose(bool disposing) {
            context.Dispose();
        }


        // GET: Customers
        //[Authorize]       //Apply authorization to one action
        public ActionResult Index() {
            return View();
        }

        public ActionResult Details(int id) {
            //var customer = context.Customers.SingleOrDefault(c => c.Id == id);
            var customer = context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if(customer == null) return HttpNotFound();
            return View(customer);
        }

        public ActionResult New() {
            var membershipTypes = context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel() {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        public ActionResult Edit(int id) {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel() {
                Customer = customer,
                MembershipTypes = context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        /* MVC is smart enough to make only properties Create action
         * is get and create Customer from it
         * So we dont need this:
         * public ActionResult Create(CustomerFormViewModel viewModel)
         */
        [HttpPost]
        [ValidateAntiForgeryToken]  //Avoid sending the form from outside the page
        public ActionResult Save(Customer customer) {
            if(!ModelState.IsValid) {
                var viewModel = new CustomerFormViewModel() {
                    Customer = customer,
                    MembershipTypes = context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0) {
                context.Customers.Add(customer);
            }
            else {
                var customerInDb = context.Customers.Single(c => c.Id == customer.Id);

                //Bad app
                //TryUpdateModel(customerInDb, "", new string[] { "Name", "Email" });   //Save changes in the customer that has that id

                //customerInDb.Name = customer.Name;
                //customerInDb.Birthdate = customer.Birthdate;
                //customerInDb.MembershipTypeId = customer.MembershipTypeId;
                //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

                //Using AutoMapper is much easier and cleaner:
                Mapper.Map(customer, customerInDb);
            }
            context.SaveChanges();  //Save and commit it in the Database (Like a Transaction)
            return RedirectToAction("Index", "Customers");
        }
    }
}
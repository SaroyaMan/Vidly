using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Models;
using Vidly_New.Dtos;
using Vidly_New.Models;

namespace Vidly_New.Controllers.API {
    public class CustomersController: ApiController {

        private ApplicationDbContext context;

        public CustomersController() {
            context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers() {
            return context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id) {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer) );
        }

        // POST /api/customers
        /*
         * Another option :
         *
           public Customer PostCustomer(Customer customer) {
        }
         */
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) {
            if(!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            context.Customers.Add(customer);
            context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto) {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, customerInDb);
            //customerInDb.Name =                     customer.Name;
            //customerInDb.Birthdate =                customer.Birthdate;
            //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            //customerInDb.MembershipTypeId =         customer.MembershipTypeId;

            context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id) {
            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            context.Customers.Remove(customerInDb);
            context.SaveChanges();
        }
    }
}
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Models;
using Vidly_New.App_Start;
using Vidly_New.Dtos;
using Vidly_New.Models;

namespace Vidly_New.Controllers.API {
    public class CustomersController: ApiController {

        private ApplicationDbContext context;

        public CustomersController() {
            context = new ApplicationDbContext();

            Mapper.Initialize(cfg => {
                cfg.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<MembershipType, MembershipTypeDto>();
            });
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers(string query = null) {
            var customersQuery = context.Customers.Include(c => c.MembershipType);
            if(!String.IsNullOrWhiteSpace(query)) {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }
            var customersDto = customersQuery.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customersDto);
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
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto) {
            if(!ModelState.IsValid)
                return BadRequest();
            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb == null)
                return NotFound();
            Mapper.Map(customerDto, customerInDb);
            //customerInDb.Name =                     customer.Name;
            //customerInDb.Birthdate =                customer.Birthdate;
            //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            //customerInDb.MembershipTypeId =         customer.MembershipTypeId;

            context.SaveChanges();
            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id) {
            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb == null) return NotFound();
            context.Customers.Remove(customerInDb);
            context.SaveChanges();
            return Ok();
        }
    }
}
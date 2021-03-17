using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;
using System.Data.Entity;
namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {


        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        ///  get api/customers
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetCusotmers(string query = null){
            var customersQuery = _context.Customer
                                 .Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(query))
            {
              customersQuery=  customersQuery.Where(c =>c.Name.Contains(query)); 
            }




                var customerxDtos = customersQuery                                        
                                          .ToList()
                                         .Select(Mapper.Map<Customer, CustomerDto>);



            return Ok(customerxDtos);


        }

        ///  get api/customers/1
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer==null)
            {
                return NotFound();
            }


            return Ok(Mapper.Map<Customer,CustomerDto>(customer));




        }


        ///  post api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }


            var customer =Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customer.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }

        ///  put api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();

            }




            var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();

            }

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            return Ok();


        }
        ///  delete api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customerInDb==null)
            {
                return NotFound();
            }


            _context.Customer.Remove(customerInDb);

            _context.SaveChanges();



            return Ok();

        }




    }
}

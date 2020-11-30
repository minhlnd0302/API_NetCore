﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ActionModels.CustomersMGT;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly TGDDContext _context;

        public CustomersController(TGDDContext context)
        {
            _context = context;
        }

        // GET: Customers
        // get all customers
        [Authorize(Roles = "0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            CustomersGetAll customerGetAll = new CustomersGetAll();
            return await customerGetAll.Excute();
        }

        // GET: Customers/5
        // get info user from id
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerFromId(long id)
        { 
            CustomersGetById customersGetById = new CustomersGetById { Id = id };

            return await customersGetById.Excute();
        }


        //get customer from username
        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomerFromUserName(string username)
        {

            CustomersGetByUserName customersGetByUserName = new CustomersGetByUserName { Username = username };

            return await customersGetByUserName.Excute();
        }


        [HttpGet("{username}")]
        public async Task<ActionResult<Customer>> GetCustomerFromUsername(string username)
        {
            var customer = await _context.Customers.FindAsync(username);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(long id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

         
        // create customer

        [HttpPost("add")]
        public async Task<ActionResult<Customer>> PostCustomers(Customer customer)
        {
            _context.Customers.Add(customer);
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomersExists(customer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomers", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomers(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomersExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}

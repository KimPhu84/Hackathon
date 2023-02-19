using Microsoft.AspNetCore.Mvc;
using BodyBuilderApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BodyBuilderApp.Modules.CustomerModule.Interface;
using BodyBuilderApp.Modules.CustomerModule.Request;
using Microsoft.AspNetCore.Authorization;

namespace Traibanhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;
        
        public CustomersController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }
            // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            try
            {
                var response = await _CustomerService.GetAll();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer([FromRoute] string id)
        {
            var Customer = await _CustomerService.GetCustomerByID(id);

            if (Customer == null)
            {
                return NotFound();
            }

            return Customer;
        }
        [HttpGet("{email},{password}")]
        public async Task<ActionResult<Customer>> GetEmail([FromRoute] string email,string password)
        {
           var Customer = await _CustomerService.GetCustomerByEmail(email,password);
            
            if (Customer == null)
            {
                return NotFound();
            }

            return Customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutCustomer([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            var check = await _CustomerService.AddNewCustomer(createCustomerRequest);
            if(check) return Ok();
            else return BadRequest();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer([FromBody] UpdateCustomerRequest updateCustomerRequest)
        {
            var check = await _CustomerService.UpdateCustomer(updateCustomerRequest);
            if (check) return Ok();
            else return BadRequest();
        }

        //// DELETE: api/Customers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
        //{
        //    var Customer = await _CustomerService.GetCustomerByID(id);
        //    if (Customer == null)
        //    {
        //        return NotFound();
        //    }
        //    //await _typeService.DeleteType(type);
        //    await _CustomerService.(Customer.BasketId);

        //    return Ok();
        //}

    }
}

using Microsoft.AspNetCore.Mvc;
using Task21.Models;
using Task21.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Task21.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerDataContext _context;

        public CustomerController(CustomerDataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _context.customer.ToList();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _context.customer.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.customer.Add(customer);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer updatedCustomer)
        {
            if (id != updatedCustomer.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.customer.Update(updatedCustomer);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _context.customer.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            _context.customer.Remove(customer);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

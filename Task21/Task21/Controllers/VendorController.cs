using Microsoft.AspNetCore.Mvc;
using Task21.Models;
using Task21.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Task21.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : ControllerBase
    {
        private readonly CustomerDataContext _context;

        public VendorController(CustomerDataContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            var vendors = _context.vendor.ToList();
            return Ok(vendors);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var vendor = _context.vendor.FirstOrDefault(v => v.Id == id);
            if (vendor == null)
                return NotFound();
            return Ok(vendor);
        }

        
        [HttpPost]
        public IActionResult Create(Vendor vendor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.vendor.Add(vendor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = vendor.Id }, vendor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Vendor updatedVendor)
        {
            if (id != updatedVendor.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = _context.vendor.FirstOrDefault(v => v.Id == id);
            if (existing == null)
                return NotFound();

            _context.Entry(existing).CurrentValues.SetValues(updatedVendor);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var vendor = _context.vendor.FirstOrDefault(v => v.Id == id);
            if (vendor == null)
                return NotFound();

            _context.vendor.Remove(vendor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

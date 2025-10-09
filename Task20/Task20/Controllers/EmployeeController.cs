using Microsoft.AspNetCore.Mvc;
using Task20.Models;
using Task20.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Task20.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly EmployeeDataContext _context;

        public EmployeeController(EmployeeDataContext context)
        {
            _context=context;
        }

        
        public IActionResult Index()
        {
            var Emp = _context.Emp.ToList();
            return View(Emp);
        }


        public IActionResult Create()
        {
            
            return View();
            
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
           if(ModelState.IsValid)
            {
                _context.Emp.Add(emp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);

        }


        public IActionResult Edit(int id)
        {
            var emp = _context.Emp.FirstOrDefault(e => e.Id == id);
            if (emp==null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee UpdatedEmp)
        {
            if(ModelState.IsValid)
            {
                _context.Emp.Update(UpdatedEmp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(UpdatedEmp);

        }


        public IActionResult Delete(int id)
        {
            var emp = _context.Emp.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                _context.Emp.Remove(emp);
                _context.SaveChanges();
               
            }
            return RedirectToAction("Index");


        }
        


        public IActionResult Details(int id)
        {
            var emp = _context.Emp.FirstOrDefault(e => e.Id == id);
            if(emp==null)
            {
                return NotFound();
            }
            return View(emp);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using CrudApp.Models;

namespace CrudApp.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John", Position = "Developer" },
            new Employee { Id = 2, Name = "Jane", Position = "Designer" }
        };

        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee updatedEmployee)
        {
            var emp = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (emp != null)
            {
                emp.Name = updatedEmployee.Name;
                emp.Position = updatedEmployee.Position;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null) employees.Remove(emp);
            return RedirectToAction("Index");
        }
    }
}

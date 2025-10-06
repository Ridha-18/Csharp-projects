using Microsoft.AspNetCore.Mvc;
using Task19.DataContext; 
using Task19.Models;      
using System.Linq;

namespace Task19.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientDataContext _context;

        // Constructor with Dependency Injection
        public ClientController(ClientDataContext context)
        {
            _context = context;
        }

        // read
        public IActionResult Index()
        {
            var clients = _context.clients.ToList();
            return View(clients);
        }

        // create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        //edit
        public IActionResult Edit(int id)
        {
            var client = _context.clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
                return NotFound();

            return View(client);
        }

       
        [HttpPost]
        public IActionResult Edit(Client updatedClient)
        {
            if (ModelState.IsValid)
            {
                _context.clients.Update(updatedClient);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updatedClient);
        }

        // delete
        public IActionResult Delete(int id)
        {
            var client = _context.clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                _context.clients.Remove(client);
                _context.SaveChanges(); 
            }
            return RedirectToAction("Index");
        }


        //details
        public IActionResult Details(int id)
        {
            var client = _context.clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
                return NotFound();

            return View(client);
        }
    }
}

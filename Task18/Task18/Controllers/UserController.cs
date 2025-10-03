using Microsoft.AspNetCore.Mvc;
using CrudApp.Models;

namespace CrudApp.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Alice", Email = "alice@mail.com" },
            new User { Id = 2, Name = "Bob", Email = "bob@mail.com" }
        };

        public IActionResult Index()
        {
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = users.Max(u => u.Id) + 1;
            users.Add(user);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null) users.Remove(user);
            return RedirectToAction("Index");
        }
    }
}


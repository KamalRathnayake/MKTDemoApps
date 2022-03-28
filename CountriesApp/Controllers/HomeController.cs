using UsersApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CountriesApp.Data;

namespace UsersApp.Controllers
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UsersContext _context;

        public static List<User> Users { get; set; } = new List<User>();

        static bool IN_MEMORY_DB = true;

        //public HomeController(ILogger<HomeController> logger, UsersContext context)
        public HomeController(ILogger<HomeController> logger)
        {
            if (Users.Count == 0)
            {
                Users.Add(new User
                {
                    Name = "John",
                    Country = "UK"
                });
                Users.Add(new User
                {
                    Name = "Ann",
                    Country = "USA"
                });
                Users.Add(new User
                {
                    Name = "Thomas",
                    Country = "Norway"
                });
            }
            _logger = logger;
            //_context = context;
        }

        public IActionResult Index()
        {
            if (IN_MEMORY_DB)
            {
                ViewBag.Users = Users;
            }
            else
            {
                ViewBag.Users = _context.Users.ToList();
            }
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (IN_MEMORY_DB)
            {
                Users.Add(user);
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            return Redirect("/");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

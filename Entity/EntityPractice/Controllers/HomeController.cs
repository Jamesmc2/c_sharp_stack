using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityPractice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private PracticeContext dbContext;

        // here we can "inject" our context service into the constructor
        public HomeController(PracticeContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<User> AllUsers = dbContext.Users.ToList();
            ViewBag.Users = AllUsers;

            return View();
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(User NewUser)
        {
            User newUser = new User{
                FirstName = NewUser.FirstName,
                LastName = NewUser.LastName,
                Email = NewUser.Email,
                Password = NewUser.Password
            };
            
            // We can take the User object created from a form submission
            // And pass this object to the .Add() method
            dbContext.Add(newUser);
            // OR dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
            // Other code
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id){
            User Edituser = dbContext.Users.FirstOrDefault(user => user.UserId == id);

            ViewBag.User = Edituser;
            return View();
        }
    }
}
